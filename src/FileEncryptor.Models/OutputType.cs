using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Models
{
    public enum KeyOutputType
    {
        /// <summary>
        /// Print passphrase into standard output
        /// </summary>
        StdOut = 0,

        /// <summary>
        /// Write passphrase into file
        /// </summary>
        File = 1,

        /// <summary>
        /// Send passphrase via email
        /// </summary>
        Email = 2
    }
}
