using System;
using System.Diagnostics;

namespace AGCSE
{


    public class PendingBuffer
    {

        byte[] buffer_;
        int start;
        int end;
        uint bits;
        int bitCount;

        public PendingBuffer()
            : this(4096)
        {
        }


        public PendingBuffer(int bufferSize)
        {
            buffer_ = new byte[bufferSize];
        }


        public void Reset()
        {
            start = end = bitCount = 0;
        }


        public void WriteByte(int value)
        {
            if (unchecked((byte)value) != GetMSB(value))
            {
                Debug.WriteLine("Error: WriteByte1");
            }
            buffer_[end++] = unchecked((byte)value);
        }


        public void WriteShort(int value)
        {
            if (unchecked((byte)value) != GetMSB(value))
            {
                Debug.WriteLine("Error: WriteShort1");
            }
            buffer_[end++] = unchecked((byte)value);
            if (unchecked((byte)(value >> 8)) != GetMSB((value >> 8)))
            {
                Debug.WriteLine("Error: WriteShort1");
            }
            buffer_[end++] = unchecked((byte)(value >> 8));
        }


        public void WriteInt(int value)
        {
            if (unchecked((byte)value) != GetMSB(value))
            {
                Debug.WriteLine("Error: WriteInt1");
            }
            buffer_[end++] = unchecked((byte)value);
            if (unchecked((byte)(value >> 8)) != GetMSB((value >> 8)))
            {
                Debug.WriteLine("Error: WriteInt2");
            }
            buffer_[end++] = unchecked((byte)(value >> 8));
            if (unchecked((byte)(value >> 16)) != GetMSB((value >> 16)))
            {
                Debug.WriteLine("Error: WriteInt3");
            }
            buffer_[end++] = unchecked((byte)(value >> 16));
            if (unchecked((byte)(value >> 24)) != GetMSB((value >> 24)))
            {
                Debug.WriteLine("Error: WriteInt4");
            }
            buffer_[end++] = unchecked((byte)(value >> 24));
        }


        public void WriteBlock(byte[] block, int offset, int length)
        {
            System.Array.Copy(block, offset, buffer_, end, length);
            end += length;
        }


        public int BitCount
        {
            get
            {
                return bitCount;
            }
        }


        public void AlignToByte()
        {
            if (bitCount > 0)
            {
                if (unchecked((byte)bits) != GetMSB(bits))
                {
                    Debug.WriteLine("Error: AlignToByte2");
                }
                buffer_[end++] = unchecked((byte)bits);
                if (bitCount > 8)
                {
                    if (unchecked((byte)(bits >> 8)) != GetMSB((bits >> 8)))
                    {
                        Debug.WriteLine("Error: AlignToByte2");
                    }
                    buffer_[end++] = unchecked((byte)(bits >> 8));
                }
            }
            bits = 0;
            bitCount = 0;
        }


        public void WriteBits(int b, int count)
        {
            bits |= (uint)(b << bitCount);
            bitCount += count;
            if (bitCount >= 16)
            {
                if (unchecked((byte)bits) != GetMSB(bits))
                {
                    Debug.WriteLine("Error: WriteBits1");
                }
                buffer_[end++] = unchecked((byte)bits);
                if (unchecked((byte)(bits >> 8)) != GetMSB((bits >> 8)))
                {
                    Debug.WriteLine("Error: WriteBits2");
                }
                buffer_[end++] = unchecked((byte)(bits >> 8));
                bits >>= 16;
                bitCount -= 16;
            }
        }


        public void WriteShortMSB(int s)
        {
            if (unchecked((byte)(s >> 8)) != GetMSB((s >> 8)))
            {
                Debug.WriteLine("Error: WriteShortMSB1");
            }
            buffer_[end++] = unchecked((byte)(s >> 8));
            if (unchecked((byte)s) != GetMSB(s))
            {
                Debug.WriteLine("Error: WriteShortMSB2");
            }
            buffer_[end++] = unchecked((byte)s);
        }

        public bool IsFlushed
        {
            get
            {
                return end == 0;
            }
        }

        public int Flush(byte[] output, int offset, int length)
        {
            if (bitCount >= 8)
            {
                if (unchecked((byte)bits) != GetMSB(bits))
                {
                    Debug.WriteLine("Flush1");
                }
                buffer_[end++] = unchecked((byte)bits);
                bits >>= 8;
                bitCount -= 8;
            }

            if (length > end - start)
            {
                length = end - start;
                System.Array.Copy(buffer_, start, output, offset, length);
                start = 0;
                end = 0;
            }
            else
            {
                System.Array.Copy(buffer_, start, output, offset, length);
                start += length;
            }
            return length;
        }

        public byte[] ToByteArray()
        {
            byte[] result = new byte[end - start];
            System.Array.Copy(buffer_, start, result, 0, result.Length);
            start = 0;
            end = 0;
            return result;
        }

        private byte GetMSB(uint i)
        {
            byte[] bytes = BitConverter.GetBytes(i);
            if (BitConverter.IsLittleEndian == true)
            {
                return bytes[0];
            }
            else
            {
                return bytes[bytes.Length - 1];
            }
        }

        private byte GetMSB(int i)
        {
            byte[] bytes = BitConverter.GetBytes(i);
            if (BitConverter.IsLittleEndian == true)
            {
                return bytes[0];
            }
            else
            {
                return bytes[bytes.Length - 1];
            }
        }

    }
}
