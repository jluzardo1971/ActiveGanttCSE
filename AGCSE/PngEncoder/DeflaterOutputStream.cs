using System;
using System.IO;

namespace AGCSE
{

    public class DeflaterOutputStream : Stream
    {

        byte[] buffer_;
        protected Deflater deflater_;
        protected Stream baseOutputStream_;
        bool isClosed_;
        bool isStreamOwner_ = true;
        string password;
        uint[] keys;

        public DeflaterOutputStream(Stream baseOutputStream)
            : this(baseOutputStream, new Deflater(), 512)
        {
        }


        public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater)
            : this(baseOutputStream, deflater, 512)
        {
        }


        public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater, int bufferSize)
        {
            if (baseOutputStream == null)
            {
                throw new ArgumentNullException("baseOutputStream");
            }

            if (baseOutputStream.CanWrite == false)
            {
                throw new ArgumentException("Must support writing", "baseOutputStream");
            }

            if (deflater == null)
            {
                throw new ArgumentNullException("deflater");
            }

            if (bufferSize <= 0)
            {
                throw new ArgumentOutOfRangeException("bufferSize");
            }

            baseOutputStream_ = baseOutputStream;
            buffer_ = new byte[bufferSize];
            deflater_ = deflater;
        }

        public virtual void Finish()
        {
            deflater_.Finish();
            while (!deflater_.IsFinished)
            {
                int len = deflater_.Deflate(buffer_, 0, buffer_.Length);
                if (len <= 0)
                {
                    break;
                }

                if (keys != null)
                {
                    EncryptBlock(buffer_, 0, len);
                }

                baseOutputStream_.Write(buffer_, 0, len);
            }

            if (!deflater_.IsFinished)
            {
                throw new Exception("Can't deflate all input?");
            }

            baseOutputStream_.Flush();


            if (keys != null)
            {
                keys = null;
            }

        }


        public bool IsStreamOwner
        {
            get { return isStreamOwner_; }
            set { isStreamOwner_ = value; }
        }


        public bool CanPatchEntries
        {
            get
            {
                return baseOutputStream_.CanSeek;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if ((value != null) && (value.Length == 0))
                {
                    password = null;
                }
                else
                {
                    password = value;
                }
            }
        }


        protected void EncryptBlock(byte[] buffer, int offset, int length)
        {
            for (int i = offset; i < offset + length; ++i)
            {
                byte oldbyte = buffer[i];
                buffer[i] ^= EncryptByte();
                UpdateKeys(oldbyte);
            }
        }


        protected byte EncryptByte()
        {
            uint temp = ((keys[2] & 0xFFFF) | 2);
            return (byte)((temp * (temp ^ 1)) >> 8);
        }

	
        protected void UpdateKeys(byte ch)
        {
            keys[0] = Crc32.ComputeCrc32(keys[0], ch);
            keys[1] = keys[1] + (byte)keys[0];
            keys[1] = keys[1] * 134775813 + 1;
            keys[2] = Crc32.ComputeCrc32(keys[2], (byte)(keys[1] >> 24));
        }


        protected void Deflate()
        {
            while (!deflater_.IsNeedingInput)
            {
                int deflateCount = deflater_.Deflate(buffer_, 0, buffer_.Length);

                if (deflateCount <= 0)
                {
                    break;
                }

                if (keys != null)
                {
                    EncryptBlock(buffer_, 0, deflateCount);
                }

                baseOutputStream_.Write(buffer_, 0, deflateCount);
            }

            if (!deflater_.IsNeedingInput)
            {
                throw new Exception("DeflaterOutputStream can't deflate all input?");
            }
        }


        public override bool CanRead
        {
            get
            {
                return false;
            }
        }


        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }


        public override bool CanWrite
        {
            get
            {
                return baseOutputStream_.CanWrite;
            }
        }


        public override long Length
        {
            get
            {
                return baseOutputStream_.Length;
            }
        }


        public override long Position
        {
            get
            {
                return baseOutputStream_.Position;
            }
            set
            {
                throw new NotSupportedException("Position property not supported");
            }
        }


        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("DeflaterOutputStream Seek not supported");
        }


        public override void SetLength(long value)
        {
            throw new NotSupportedException("DeflaterOutputStream SetLength not supported");
        }


        public override int ReadByte()
        {
            throw new NotSupportedException("DeflaterOutputStream ReadByte not supported");
        }


        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException("DeflaterOutputStream Read not supported");
        }


        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            throw new NotSupportedException("DeflaterOutputStream BeginRead not currently supported");
        }


        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            throw new NotSupportedException("BeginWrite is not supported");
        }


        public override void Flush()
        {
            deflater_.Flush();
            Deflate();
            baseOutputStream_.Flush();
        }

        public override void Close()
        {
            if (!isClosed_)
            {
                isClosed_ = true;

                try
                {
                    Finish();

                    keys = null;
                }
                finally
                {
                    if (isStreamOwner_)
                    {
                        baseOutputStream_.Close();
                    }
                }
            }
        }


        public override void WriteByte(byte value)
        {
            byte[] b = new byte[1];
            b[0] = value;
            Write(b, 0, 1);
        }


        public override void Write(byte[] buffer, int offset, int count)
        {
            deflater_.SetInput(buffer, offset, count);
            Deflate();
        }

    }
}
