using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Models
{
    public enum InputType
    {
        /// <summary>
        /// Read input string via Standard Input (Console)
        /// </summary>
        StdIn = 0,

        /// <summary>
        /// Read input string from file
        /// </summary>
        File = 1
    }
}
