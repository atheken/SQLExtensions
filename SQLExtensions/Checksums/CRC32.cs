using System;
using System.Security.Cryptography;

namespace ComputeFileHashes
{
    /// <summary>
    /// HashAlgorithm implementation for CRC-32.
    /// </summary>
    ///<remarks>
    /// This implementation of CRC-32 was generously published by "Delay"
    /// http://blogs.msdn.com/delay/archive/2009/01/14/free-hash-a-reusable-crc-32-hashalgorithm-implementation-for-net.aspx
    /// 
    /// ALSO:
    /// http://blogs.msdn.com/delay/archive/2009/01/13/trust-but-verify-free-tool-and-source-code-for-computing-commonly-used-hash-codes.aspx
    /// 
    /// The license is not explicit, but seems to be "use it for whatever you wish"
    /// </remarks>
    public class CRC32 : HashAlgorithm
    {
        // Shared, pre-computed lookup table for efficiency
        private static readonly uint[] _crc32Table;

        /// <summary>
        /// Initializes the shared lookup table.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification =
            "Table values must be computed; not possible to remove the static constructor.")]
        static CRC32()
        {
            // Allocate table
            _crc32Table = new uint[256];

            // For each byte
            for (uint n = 0; n < 256; n++)
            {
                // For each bit
                uint c = n;
                for (int k = 0; k < 8; k++)
                {
                    // Compute value
                    if (0 != (c & 1))
                    {
                        c = 0xedb88320 ^ (c >> 1);
                    }
                    else
                    {
                        c = c >> 1;
                    }
                }

                // Store result in table
                _crc32Table[n] = c;
            }
        }

        // Current hash value
        private uint _crc32Value = uint.MaxValue;

        /// <summary>
        /// Initializes the variables.
        /// </summary>
        public override void Initialize()
        {
            _crc32Value = uint.MaxValue;
        }

        /// <summary>
        /// Updates the hash code for the provided data.
        /// </summary>
        /// <param name="array">Data.</param>
        /// <param name="ibStart">Start position.</param>
        /// <param name="cbSize">Number of bytes.</param>
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            for (int i = ibStart; i < cbSize; i++)
            {
                byte index = (byte)(_crc32Value ^ array[i]);
                _crc32Value = _crc32Table[index] ^ ((_crc32Value >> 8) & 0xffffff);
            }
        }

        /// <summary>
        /// Finalizes the hash code and returns it.
        /// </summary>
        /// <returns></returns>
        protected override byte[] HashFinal()
        {
            return Hash;
        }

        /// <summary>
        /// Returns the hash as an array of bytes.
        /// </summary>
        public override byte[] Hash
        {
            get
            {
                // Convert complement of hash code to byte array
                byte[] bytes = BitConverter.GetBytes(~_crc32Value);

                // Reverse for proper endianness, and return
                Array.Reverse(bytes);
                return bytes;
            }
        }

        // Return size of hash in bits.
        public override int HashSize
        {
            get
            {
                return Hash.Length * 8;
            }
        }
    }
}