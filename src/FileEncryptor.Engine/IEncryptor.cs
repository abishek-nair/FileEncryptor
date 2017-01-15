using System.IO;

namespace FileEncryptor.Engine
{
    public interface IEncryptor
    {
        byte[] SecretKey { get; set; }
        byte[] InitVector { get; set; }

        byte[] Encrypt(byte[] inputMessageBytes);
    }
}