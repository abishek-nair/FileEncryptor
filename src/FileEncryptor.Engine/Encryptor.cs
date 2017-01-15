using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace FileEncryptor.Engine
{
    public class Encryptor : IEncryptor
    {
        public byte[] SecretKey { get; set; }
        public byte[] InitVector { get; set; }

        public Encryptor()
        {
            using (var aes = Aes.Create())
            {
                this.SecretKey = aes.Key;
                this.InitVector = aes.IV;
            }
        }

        public byte[] Encrypt(byte[] message)
        {
            byte[] encryptedMessageBytes; 
            using(var aes = Aes.Create())
            {
                aes.Key = this.SecretKey;
                aes.IV = this.InitVector;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream())
                {
                    using(var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(message);
                        }

                    }

                    encryptedMessageBytes = memoryStream.ToArray();
                }
            }

            return encryptedMessageBytes;
        }
    }
}
