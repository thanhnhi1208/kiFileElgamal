using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Security_Elgamal.Model
{
    internal class DigitalSignature
    {
        public PublicKey PublicKey { get; set; }
        public PrivateKey PrivateKey { get; set; }

        public BigInteger K { get; set; }

        public DigitalSignature() 
        { 
            PublicKey = new PublicKey();
            PrivateKey = new PrivateKey(PublicKey.P);
            PublicKey.Beta = PublicKey.TinhSoBeta(PublicKey.Alpha, PrivateKey.A, PublicKey.P);
            //K = TaoSoK(PublicKey.P);
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

        private BigInteger TinhNghichDaoMod(BigInteger e, BigInteger m)
        {
            BigInteger t1 = 0;
            BigInteger t2 = 1;
            BigInteger r = 0;
            BigInteger q = 0;
            BigInteger t = 0;
            BigInteger temp_m = m;
            while (e > 1)
            {
                q = m / e;
                r = m % e;
                t = t1 - (q * t2);

                m = e;
                e = r;
                t1 = t2;
                t2 = t;
            }

            return (t2 + temp_m) % temp_m;
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

        private BigInteger TimUocChungLonNhat(BigInteger a, BigInteger b)
        {
            while (a > 0 && b > 0)
            {
                if (a > b) a = a % b;
                else b = b % a;
            }

            return a > 0 ? a : b;
        }

        // 1 < k < p - 1, gcd(k, p - 1) = 1 (là ước chung lớn nhất =1)
        public BigInteger TaoSoK(BigInteger p)
        {
            BigInteger k;
            while (true)
            {
                k = GenerateRandomBigInteger(2, p - 1);

                if (TimUocChungLonNhat(k, p - 1) == 1) break;
            }

            return k;
        }

        // 0 <= m <= p-1
        public BigInteger TinhSoMTuFile(string path, BigInteger p)
        {
            string filePath = path;

            // 1. Đọc nội dung file thành byte[]
            byte[] fileBytes = File.ReadAllBytes(filePath);

            // 2. Tính SHA256
            byte[] hash = SHA256.Create().ComputeHash(fileBytes);

            BigInteger m = new BigInteger(hash) % p;
            Console.WriteLine(new BigInteger(hash));
            // Nếu m < 0 thì chuyển về số dương

            if (m < 0) m += p;


            return m;
        }

        // s1 = alpha ^ k mod p
        public BigInteger TinhS1(BigInteger alpha, BigInteger k, BigInteger p)
        {
            return TinhMuMod(alpha, k, p);
        }

        // (k^-1 * (m - a * s1) ) mod p-1
        public BigInteger TinhS2(BigInteger k, BigInteger m, BigInteger a, BigInteger s1, BigInteger pTru1)
        {
            BigInteger s2 = (TinhNghichDaoMod(k, pTru1) * (m - (a * s1))) % pTru1;
            if (s2 < 0) s2 += pTru1;
            return s2;
        }

        // v1 = alpha ^ m mod p
        // v2 = (Beta ^ s1  * s1 ^ s2) mod p
        public bool XacMinhChuKy(BigInteger alpha, BigInteger m, BigInteger p, BigInteger beta, BigInteger s1, BigInteger s2)
        {
            BigInteger v1 = TinhMuMod(alpha, m, p);
            BigInteger v2 = (TinhMuMod(beta, s1, p) * TinhMuMod(s1, s2, p)) % p;
            return v1 == v2;
        }
    }
}
