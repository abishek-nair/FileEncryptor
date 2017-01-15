using FileEncryptor.Engine.MessageFetcher;
using FileEncryptor.Engine.OutputHandler;
using FileEncryptor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptor.Engine
{
    public class EncryptionManager : IEncryptionManager
    {
        public EncryptionTaskProperty EncryptionProperty { get; set; }
        public IMessageFetcher MessageFetcher { get; set; }
        public IKeyOutputHandler KeyOutputHandler { get; set; }

        public EncryptionManager(EncryptionTaskProperty property, IMessageFetcher messageFetcher, IKeyOutputHandler keyOutputHandler)
        {
            this.EncryptionProperty = property;
            this.MessageFetcher = messageFetcher;
            this.KeyOutputHandler = keyOutputHandler;
        }

        public void Encrypt()
        {
            var plaintextMessageEnumerable = this.MessageFetcher.Fetch();

            var encryptor = new Encryptor();

            foreach(var plaintext in plaintextMessageEnumerable)
            {
                var encryptedMessageBytes = encryptor.Encrypt(Encoding.UTF8.GetBytes(plaintext));
                //var encryptedMessage = Encoding.UTF8.GetString(encryptedMessageBytes);
                var encodedEncryptedMessage = Convert.ToBase64String(encryptedMessageBytes);
                Console.WriteLine($"EncMess: {encodedEncryptedMessage}");
            }

            var keyString = Encoding.UTF32.GetString(encryptor.SecretKey);
            var ivString = Encoding.UTF32.GetString(encryptor.InitVector);

            this.KeyOutputHandler.Handle($"{keyString}:{ivString}");
        }
    }
}
