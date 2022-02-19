

using System;
using System.IO;
using System.Diagnostics;

namespace AGCSE
{
    public class PngEncoder
    {
        public const bool ENCODE_ALPHA = true;
        public const bool NO_ALPHA = false;
        public const int FILTER_NONE = 0;
        public const int FILTER_SUB = 1;
        public const int FILTER_UP = 2;
        public const int FILTER_LAST = 2;
        protected static byte[] IHDR = new byte[] { 73, 72, 68, 82 };
        protected static byte[] IDAT = new byte[] { 73, 68, 65, 84 };
        protected static byte[] IEND = new byte[] { 73, 69, 78, 68 };
        protected byte[] pngBytes;
        protected byte[] priorRow;
        protected byte[] leftBytes;
        protected int width, height;
        protected int bytePos, maxPos;
        protected Crc32 crc = new Crc32();
        protected long crcValue;
        protected bool encodeAlpha;
        protected int filter;
        protected int bytesPerPixel;
        protected int compressionLevel;
        protected int[] pixelData;

        public PngEncoder(int[] pixel_data, int width, int height, bool encodeAlpha, int whichFilter, int compLevel)
        {
            this.pixelData = pixel_data;
            this.width = width;
            this.height = height;
            this.encodeAlpha = encodeAlpha;

            this.filter = FILTER_NONE;
            if (whichFilter <= FILTER_LAST)
            {
                this.filter = whichFilter;
            }

            if (compLevel >= 0 && compLevel <= 9)
            {
                this.compressionLevel = compLevel;
            }
        }

        public byte[] Encode(bool encodeAlpha)
        {
            byte[] pngIdBytes = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            pngBytes = new byte[((width + 1) * height * 3) + 200];
            maxPos = 0;
            bytePos = WriteBytes(pngIdBytes, 0);
            Debug.WriteLine("");
            writeHeader();
            if (WriteImageData())
            {
                writeEnd();
                pngBytes = ResizeByteArray(pngBytes, maxPos);
            }
            else
            {
                pngBytes = null;
            }
            return pngBytes;
        }

        public byte[] pngEncode()
        {
            return Encode(encodeAlpha);
        }


        protected byte[] ResizeByteArray(byte[] array, int newLength)
        {
            byte[] newArray = new byte[newLength];
            int oldLength = array.Length;

            Array.Copy(array, 0, newArray, 0, Math.Min(oldLength, newLength));
            return newArray;
        }


        protected int WriteBytes(byte[] data, int offset)
        {
            maxPos = Math.Max(maxPos, offset + data.Length);
            if (data.Length + offset > pngBytes.Length)
                pngBytes = ResizeByteArray(pngBytes, pngBytes.Length + Math.Max(1000, data.Length));

            Array.Copy(data, 0, pngBytes, offset, data.Length);
            return offset + data.Length;
        }

        protected int WriteBytes(byte[] data, int nBytes, int offset)
        {
            maxPos = Math.Max(maxPos, offset + nBytes);
            if (nBytes + offset > pngBytes.Length)
                pngBytes = ResizeByteArray(pngBytes, pngBytes.Length + Math.Max(1000, nBytes));

            Array.Copy(data, 0, pngBytes, offset, nBytes);
            return offset + nBytes;
        }


        protected int WriteInt2(int n, int offset)
        {
            byte[] temp = { (byte)((n >> 8) & 0xff), (byte)(n & 0xff) };

            return WriteBytes(temp, offset);
        }


        protected int WriteInt4(int n, int offset)
        {
            byte[] temp = {(byte) ((n >> 24) & 0xff),
                       (byte) ((n >> 16) & 0xff),
                       (byte) ((n >> 8) & 0xff),
                       (byte) (n & 0xff)};

            return WriteBytes(temp, offset);
        }


        protected int WriteByte(int b, int offset)
        {
            byte[] temp = { (byte)b };

            return WriteBytes(temp, offset);
        }

        protected void writeHeader()
        {
            int startPos;

            startPos = bytePos = WriteInt4(13, bytePos);

            bytePos = WriteBytes(IHDR, bytePos);
            bytePos = WriteInt4(width, bytePos);
            bytePos = WriteInt4(height, bytePos);
            bytePos = WriteByte(8, bytePos); 
            bytePos = WriteByte((encodeAlpha) ? 6 : 2, bytePos); 
            bytePos = WriteByte(0, bytePos); 
            bytePos = WriteByte(0, bytePos); 
            bytePos = WriteByte(0, bytePos); 

            crc.Reset();
            crc.Update(pngBytes, startPos, bytePos - startPos);
            crcValue = crc.Value;

            bytePos = WriteInt4((int)crcValue, bytePos);
        }

        protected void FilterSub(byte[] pixels, int startPos, int width)
        {
            int i;
            int offset = bytesPerPixel;
            int actualStart = startPos + offset;
            int nBytes = width * bytesPerPixel;
            int leftInsert = offset;
            int leftExtract = 0;

            for (i = actualStart; i < startPos + nBytes; i++)
            {
                leftBytes[leftInsert] = pixels[i];
                pixels[i] = (byte)((pixels[i] - leftBytes[leftExtract]) % 256);
                leftInsert = (leftInsert + 1) % 0x0f;
                leftExtract = (leftExtract + 1) % 0x0f;
            }
        }


        protected void FilterUp(byte[] pixels, int startPos, int width)
        {
            int i, nBytes;
            byte currentByte;

            nBytes = width * bytesPerPixel;

            for (i = 0; i < nBytes; i++)
            {
                currentByte = pixels[startPos + i];
                pixels[startPos + i] = (byte)((pixels[startPos + i] - priorRow[i]) % 256);
                priorRow[i] = currentByte;
            }
        }


        protected bool WriteImageData()
        {
            int rowsLeft = height;  
            int startRow = 0;       
            int nRows;              

            byte[] scanLines;       
            int scanPos;            
            int startPos;           

            byte[] compressedLines; 
            int nCompressed;        


            bytesPerPixel = (encodeAlpha) ? 4 : 3;

            Deflater scrunch = new Deflater(compressionLevel);
            MemoryStream outBytes = new MemoryStream(1024);

            DeflaterOutputStream compBytes = new DeflaterOutputStream(outBytes, scrunch);
            try
            {
                while (rowsLeft > 0)
                {
                    nRows = Math.Min(32767 / (width * (bytesPerPixel + 1)), rowsLeft);
                    nRows = Math.Max(nRows, 1);

                    int[] pixels = new int[width * nRows];
                    Array.Copy(this.pixelData, width * startRow, pixels, 0, width * nRows);


                    scanLines = new byte[width * nRows * bytesPerPixel + nRows];

                    if (filter == FILTER_SUB)
                    {
                        leftBytes = new byte[16];
                    }
                    if (filter == FILTER_UP)
                    {
                        priorRow = new byte[width * bytesPerPixel];
                    }

                    scanPos = 0;
                    startPos = 1;
                    for (int i = 0; i < width * nRows; i++)
                    {
                        if (i % width == 0)
                        {
                            scanLines[scanPos++] = (byte)filter;
                            startPos = scanPos;
                        }
                        scanLines[scanPos++] = (byte)((pixels[i] >> 16) & 0xff);
                        scanLines[scanPos++] = (byte)((pixels[i] >> 8) & 0xff);
                        scanLines[scanPos++] = (byte)((pixels[i]) & 0xff);
                        if (encodeAlpha)
                        {
                            scanLines[scanPos++] = (byte)((pixels[i] >> 24) & 0xff);
                        }
                        if ((i % width == width - 1) && (filter != FILTER_NONE))
                        {
                            if (filter == FILTER_SUB)
                            {
                                FilterSub(scanLines, startPos, width);
                            }
                            if (filter == FILTER_UP)
                            {
                                FilterUp(scanLines, startPos, width);
                            }
                        }
                    }


                    compBytes.Write(scanLines, 0, scanPos);

                    startRow += nRows;
                    rowsLeft -= nRows;
                }
                compBytes.Close();


                compressedLines = outBytes.ToArray();
                nCompressed = compressedLines.Length;

                crc.Reset();
                bytePos = WriteInt4(nCompressed, bytePos);
                bytePos = WriteBytes(IDAT, bytePos);
                crc.Update(IDAT);
                bytePos = WriteBytes(compressedLines, nCompressed, bytePos);
                crc.Update(compressedLines, 0, nCompressed);

                crcValue = crc.Value;
                bytePos = WriteInt4((int)crcValue, bytePos);
                scrunch.Finish();
                return true;
            }
            catch
            {
                return false;
            }
        }


        protected void writeEnd()
        {
            bytePos = WriteInt4(0, bytePos);
            bytePos = WriteBytes(IEND, bytePos);
            crc.Reset();
            crc.Update(IEND);
            crcValue = crc.Value;
            bytePos = WriteInt4((int)crcValue, bytePos);
        }
    }
}