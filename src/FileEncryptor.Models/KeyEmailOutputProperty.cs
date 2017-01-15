using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Models
{
    public class KeyEmailOutputProperty : IKeyOutputProperty
    {
        public List<string> EmailAddresses { get; set; }

        public KeyEmailOutputProperty(List<string> emailAddresses)
        {
            this.EmailAddresses = emailAddresses;
        }
    }
}
