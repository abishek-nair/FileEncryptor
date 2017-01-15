using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Engine.OutputHandler
{
    public interface IKeyOutputHandler
    {
        void Handle(string key);
    }
}
