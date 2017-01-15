using FileEncryptor.Engine.MessageFetcher;
using FileEncryptor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Engine
{
    public static class MessageFetcherFactory
    {
        public static IMessageFetcher GetMessageFetcher(EncryptionTaskProperty property)
        {
            switch (property.InputType)
            {
                case InputType.StdIn:
                    return new ConsoleInputMessageFetcher();

                case InputType.File:
                    var fileInputProperty = property.MessageInputProperty as FileInputProperty;
                    if(fileInputProperty == null)
                    {
                        return null;
                    }
                    return new FileInputMessageFetcher(fileInputProperty.FileNames);

                default:
                    return null;
            }
        }
    }
}
