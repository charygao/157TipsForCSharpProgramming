using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Tip117
{
    public class RSAProcessor
    {
        public static void CreateRSAKey(ref string publicKey, ref string pfxKey)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            pfxKey = provider.ToXmlString(true);
            publicKey = provider.ToXmlString(false);
        }

        public static string RSAEncrypt(string xmlPublicKey, string m_strEncryptString)
        {
            byte[] btEncryptedSecret = Encoding.UTF8.GetBytes(m_strEncryptString);
            btEncryptedSecret = CRSAWrap.EncryptBuffer(xmlPublicKey, btEncryptedSecret);
            return Convert.ToBase64String(btEncryptedSecret);
        }

        public static string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)
        {
            byte[] btDecryptedSecred = Convert.FromBase64String(m_strDecryptString);
            btDecryptedSecred = CRSAWrap.DecryptBuffer(xmlPrivateKey, btDecryptedSecred);
            return Encoding.UTF8.GetString(btDecryptedSecred);
        }

        class CRSAWrap
        {
            public static byte[] EncryptBuffer(string rsaKeyString, byte[] btSecret)
            {
                int keySize = 0;
                int blockSize = 0;
                int lastblockSize = 0;
                int counter = 0;
                int iterations = 0;
                int index = 0;
                byte[] btPlaintextToken;
                byte[] btEncryptedToken;
                byte[] btEncryptedSecret;
                RSACryptoServiceProvider rsaSender = new RSACryptoServiceProvider();
                rsaSender.FromXmlString(rsaKeyString);
                keySize = rsaSender.KeySize / 8;
                blockSize = keySize - 11;

                if ((btSecret.Length % blockSize) != 0)
                {
                    iterations = btSecret.Length / blockSize + 1;
                }
                else
                {
                    iterations = btSecret.Length / blockSize;
                }
                btPlaintextToken = new byte[blockSize];
                btEncryptedSecret = new byte[iterations * keySize];
                for (index = 0, counter = 0; counter < iterations; counter++, index += blockSize)
                {
                    if (counter == (iterations - 1))
                    {
                        lastblockSize = btSecret.Length % blockSize;
                        btPlaintextToken = new byte[lastblockSize];
                        Array.Copy(btSecret, index, btPlaintextToken, 0, lastblockSize);
                    }
                    else
                    {
                        Array.Copy(btSecret, index, btPlaintextToken, 0, blockSize);
                    }
                    btEncryptedToken = rsaSender.Encrypt(btPlaintextToken, false);
                    Array.Copy(btEncryptedToken, 0, btEncryptedSecret, counter * keySize, keySize);
                }
                return btEncryptedSecret;
            }

            public static byte[] DecryptBuffer(string rsaKeyString, byte[] btEncryptedSecret)
            {
                int keySize = 0;
                int blockSize = 0;
                int counter = 0;
                int iterations = 0;
                int index = 0;
                int byteCount = 0;
                byte[] btPlaintextToken;
                byte[] btEncryptedToken;
                byte[] btDecryptedSecret;
                RSACryptoServiceProvider rsaReceiver = new RSACryptoServiceProvider();
                rsaReceiver.FromXmlString(rsaKeyString);
                keySize = rsaReceiver.KeySize / 8;
                blockSize = keySize - 11;
                if ((btEncryptedSecret.Length % keySize) != 0)
                {
                    return null;
                }
                iterations = btEncryptedSecret.Length / keySize;
                btEncryptedToken = new byte[keySize];
                Queue<byte[]> tokenQueue = new Queue<byte[]>();
                for (index = 0, counter = 0; counter < iterations; index += blockSize, counter++)
                {
                    Array.Copy(btEncryptedSecret, counter * keySize, btEncryptedToken, 0, keySize);
                    btPlaintextToken = rsaReceiver.Decrypt(btEncryptedToken, false);
                    tokenQueue.Enqueue(btPlaintextToken);
                }
                byteCount = 0;
                foreach (var PlaintextToken in tokenQueue)
                {
                    byteCount += PlaintextToken.Length;
                }
                counter = 0;
                btDecryptedSecret = new byte[byteCount];
                foreach (var PlaintextToken in tokenQueue)
                {
                    if (counter == (iterations - 1))
                    {
                        Array.Copy(PlaintextToken, 0, btDecryptedSecret, btDecryptedSecret.Length - PlaintextToken.Length, PlaintextToken.Length);
                    }
                    else
                    {
                        Array.Copy(PlaintextToken, 0, btDecryptedSecret, counter * blockSize, blockSize);
                    }
                    counter++;
                }
                return btDecryptedSecret;
            }

        }
    }

}
