using System;

namespace AGCSE 
{

	public sealed class Adler32 : IChecksum 
    {

		const uint BASE = 65521;
        uint checksum;

		public long Value 
        {
			get 
            {
				return checksum;
			}
		}

		public Adler32() 
        {
			Reset();
		}

		public void Reset() 
        {
			checksum = 1;
		}

		public void Update(int value) 
        {
			uint s1 = checksum & 0xFFFF;
			uint s2 = checksum >> 16;

			s1 = (s1 + ((uint) value & 0xFF)) % BASE;
			s2 = (s1 + s2) % BASE;

			checksum = (s2 << 16) + s1;
		}

		public void Update(byte[] buffer) 
        {
			if (buffer == null) 
            {
				throw new ArgumentNullException("buffer");
			}

			Update(buffer, 0, buffer.Length);
		}

		public void Update(byte[] buffer, int offset, int count) 
        {
			if (buffer == null) 
            {
				throw new ArgumentNullException("buffer");
			}

			if (offset < 0) 
            {
				throw new ArgumentOutOfRangeException("offset");
			}

			if (count < 0) 
            {
				throw new ArgumentOutOfRangeException("count");
			}

			if (offset >= buffer.Length) 
            {
				throw new ArgumentOutOfRangeException("offset");
			}

			if (offset + count > buffer.Length) 
            {
				throw new ArgumentOutOfRangeException("count");
			}

			uint s1 = checksum & 0xFFFF;
			uint s2 = checksum >> 16;

			while (count > 0) 
            {

				int n = 3800;
				if (n > count) 
                {
					n = count;
				}
				count -= n;
				while (--n >= 0) 
                {
					s1 = s1 + (uint) (buffer[offset++] & 0xff);
					s2 = s2 + s1;
				}
				s1 %= BASE;
				s2 %= BASE;
			}

			checksum = (s2 << 16) | s1;
		}
	}
}
