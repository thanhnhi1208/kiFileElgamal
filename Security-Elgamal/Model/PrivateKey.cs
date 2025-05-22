using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security_Elgamal.Model
{
    internal class PrivateKey
    {
        public BigInteger A { get; set; }
        public PrivateKey(BigInteger P) 
        {
            this.A = this.TaoSoA(P);
        }

        private BigInteger GenerateRandomBigInteger(BigInteger minValue, BigInteger maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentException("minValue cannot be greater than maxValue");

            BigInteger range = maxValue - minValue;
            byte[] bytes = new byte[range.ToByteArray().Length + 1]; // +1 để tránh số âm

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                BigInteger result;
                do
                {
                    rng.GetBytes(bytes); // Sinh bytes ngẫu nhiên an toàn
                    bytes[bytes.Length - 1] = 0; // Đảm bảo số dương
                    result = new BigInteger(bytes);
                } while (result < 0 || result >= range);

                return result + minValue;
            }
        }

        // private key 1 < a < p - 1
        public BigInteger TaoSoA(BigInteger p)
        {
            return GenerateRandomBigInteger(2, p - 1);
        }
    }
}
