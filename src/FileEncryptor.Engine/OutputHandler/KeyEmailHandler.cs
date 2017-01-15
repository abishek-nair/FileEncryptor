using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Engine.OutputHandler
{
    public class KeyEmailHandler : IKeyOutputHandler
    {
        public List<string> EmailAddressList { get; set; }

        public KeyEmailHandler(List<string> emailAddresses)
        {
            this.EmailAddressList = emailAddresses;
        }

        public void Handle(string key)
        {
            throw new NotImplementedException();
        }
    }
}
