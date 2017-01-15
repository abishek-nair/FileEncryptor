using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Engine.MessageFetcher
{
    public class ConsoleInputMessageFetcher : IMessageFetcher
    {
        public IEnumerable<string> Fetch()
        {
            var consoleInput = Console.ReadLine();
            return new List<string> { consoleInput };
        }
    }
}
