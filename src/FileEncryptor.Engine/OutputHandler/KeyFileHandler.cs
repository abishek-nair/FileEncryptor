using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Engine.OutputHandler
{
    public class KeyFileHandler : IKeyOutputHandler
    {
        public string KeyFilename { get; set; }

        public KeyFileHandler()
        {
            // TODO: Fetch from Configuration file
            this.KeyFilename = "key.txt";
        }

        public KeyFileHandler(string fileName)
        {
            this.KeyFilename = fileName;
        }

        public void Handle(string key)
        {
            using (var keyFile = File.CreateText(this.KeyFilename))
            {
                keyFile.Write(key);
            }
        }
    }
}
