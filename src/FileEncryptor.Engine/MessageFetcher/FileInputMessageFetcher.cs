using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Engine.MessageFetcher
{
    public class FileInputMessageFetcher : IMessageFetcher
    {
        public List<string> FileNames { get; set; }

        public FileInputMessageFetcher(List<string> fileNames)
        {
            this.FileNames = fileNames;
        }

        public IEnumerable<string> Fetch()
        {
            var validFileNames = this.FileNames.Where(fileName => (new FileInfo(fileName)).Exists);
            
            foreach(var fileName in validFileNames)
            {
                var fileContents = File.ReadAllText(fileName);
                yield return fileContents;
            }
        }
    }
}
