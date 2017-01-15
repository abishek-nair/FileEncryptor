using FileEncryptor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor
{
    public class RawInputProperty : IMessageInputProperty
    {
        /// <summary>
        /// The message to be encrypted
        /// </summary>
        public string Message { get; set; }
    }
}
