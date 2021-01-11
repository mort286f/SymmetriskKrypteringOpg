using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetriskKrypteringOpg
{
    class Encryption
    {
        SymmetricAlgorithm symmetricAlg;
        public void GenerateSymmetricAlg(int number)
        {
            switch (number)
            {
                //DES
                case 1:
                    symmetricAlg = DES.Create();
                    break;
                //TripleDES
                case 2:
                    symmetricAlg = TripleDES.Create();
                    break;
                //Rijndael
                case 3:
                    symmetricAlg = Rijndael.Create();
                    break;
                default:
                    break;
            }
            symmetricAlg.GenerateKey();
            symmetricAlg.GenerateIV();
        }

        public byte[] GenerateRandomNumber(int count)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var numbers = new byte[count];
                randomNumberGenerator.GetBytes(numbers);

                return numbers;
            }
        }

        public byte[] Encrypt(byte[] message)
        {
            symmetricAlg.Mode = CipherMode.CBC;
            symmetricAlg.Padding = PaddingMode.PKCS7;

            using (var memoryStream = new MemoryStream())
            {
                var cryptoStream = new CryptoStream(memoryStream, symmetricAlg.CreateEncryptor(),
                    CryptoStreamMode.Write);

                cryptoStream.Write(message, 0, message.Length);
                cryptoStream.FlushFinalBlock();

                return memoryStream.ToArray();
            }
        }

        public byte[] Decrypt(byte[] encryptedMsg)
        {
            symmetricAlg.Mode = CipherMode.CBC;
            symmetricAlg.Padding = PaddingMode.PKCS7;

            using (var memoryStream = new MemoryStream())
            {
                var cryptoStream = new CryptoStream(memoryStream, symmetricAlg.CreateDecryptor(),
                    CryptoStreamMode.Write);

                cryptoStream.Write(encryptedMsg, 0, encryptedMsg.Length);
                cryptoStream.FlushFinalBlock();

                return memoryStream.ToArray();
            }
        }

    }
}
