using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Models
{
    public class KeyFileOutputProperty : IKeyOutputProperty
    {
        public string KeyFileName { get; set; }

        public KeyFileOutputProperty(string fileName)
        {
            this.KeyFileName = fileName; 
        }
    }
}
