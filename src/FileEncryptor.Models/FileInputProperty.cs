using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Models
{
    /// <summary>
    /// Properties associated with reading files to be encrypted
    /// </summary>
    public class FileInputProperty : IMessageInputProperty
    {
        public List<string> FileNames { get; set; }

        public FileInputProperty(List<string> inputFileNames)
        {
            this.FileNames = inputFileNames;
        }
    }
}
