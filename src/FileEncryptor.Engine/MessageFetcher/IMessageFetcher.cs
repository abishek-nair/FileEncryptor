using System.Collections.Generic;

namespace FileEncryptor.Engine.MessageFetcher
{
    public interface IMessageFetcher
    {
        IEnumerable<string> Fetch();
    }
}