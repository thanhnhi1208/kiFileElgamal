using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;


namespace Security_Elgamal.Model
{
    internal class PublicKey
    {
        public BigInteger P { get; set; }
        public BigInteger Alpha { get; set; }
        public BigInteger Beta { get; set; }

        public PublicKey()
        {
            this.P = this.TaoSoP();
            this.Alpha = this.TaoSoAlpha(P);
        }

     
        private BigInteger TinhMuMod(BigInteger a, BigInteger n, BigInteger m)
        {
            BigInteger t = 1;
            while (n > 0)
            {
                if (n % 2 != 0) t = t * a % m;
                a = a * a % m;
                n /= 2;
            }

            return t;
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

        private bool KiemTraSNT(BigInteger x)
        {
            if (x < 2) return false;

            for (BigInteger i = 2; i <= (BigInteger)Math.Sqrt((double)x); i++)
            {
                if (x % i == 0)
                    return false;
            }

            return true;
        }

        // p > 2 (là 1 snt)
        public BigInteger TaoSoP()
        {
            //BigInteger p;
            //while (true)
            //{
            //    p = GenerateRandomBigInteger(1000000000, 99999999999);

            //    if (KiemTraSNT(p)) break;
            //}

            //return p;

            BigInteger p;
            while (true)
            {
                p = GenerateRandomBigInteger(BigInteger.Pow(2, 32), BigInteger.Pow(2, 65));
                //p = GenerateRandomBigInteger(2, BigInteger.Pow(2, 1024));

                if (PrimeExtensions.IsProbablyPrime(p)) break;
            }

            return p;
        }

        // 1 < α < p, α^i mod p phải sinh ra tất cả giá trị từ 1 → p - 1 (không trùng).
        // α^((p−1)/2) mod p != 1
        public BigInteger TaoSoAlpha(BigInteger p)
        {
            BigInteger temp_p = p;

            p -= 1;
            List<BigInteger> factors = new List<BigInteger>();

            while (p % 2 == 0)
            {
                if (!factors.Contains(2))
                {
                    factors.Add(2);
                }
                p /= 2;
            }
            for (int i = 3; i <= p / i; i += 2)
            {
                while (p % i == 0)
                {
                    if (!factors.Contains(i))
                    {
                        factors.Add(i);
                    }
                    p /= i;
                }
            }

            if (p > 1) factors.Add(p);


            BigInteger alpha;
            int count = factors.Count;

            while (true)
            {
                bool isValid = true;
                alpha = GenerateRandomBigInteger(2, temp_p - 1);


                for (int i = 0; i < count; i++)
                {
                    if (TinhMuMod(alpha, (temp_p - 1) / factors[i], temp_p) == 1)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid) break;
            }

            return alpha;
        }

        // beta = alpha ^ a mod p
        public BigInteger TinhSoBeta(BigInteger alpha, BigInteger a, BigInteger p)
        {
            return TinhMuMod(alpha, a, p);
        }
    }
}
