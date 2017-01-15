using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Engine.OutputHandler
{
    public class KeyConsoleHandler : IKeyOutputHandler
    {
        public void Handle(string key)
        {
            Console.WriteLine(key);
        }
    }
}
