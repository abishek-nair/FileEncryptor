using FileEncryptor.Engine.OutputHandler;
using FileEncryptor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Engine
{
    public static class KeyOutputHandlerFactory
    {
        public static IKeyOutputHandler GetOutputHandler(EncryptionTaskProperty property)
        {
            switch (property.KeyOutputType)
            {
                case KeyOutputType.StdOut:
                    return new KeyConsoleHandler();

                case KeyOutputType.File:
                    var fileOutputProperty = property.KeyOutputProperty as KeyFileOutputProperty;
                    if(fileOutputProperty == null)
                    {
                        return null;
                    }

                    return new KeyFileHandler(fileOutputProperty.KeyFileName);

                case KeyOutputType.Email:
                    var emailOutputProperty = property.KeyOutputProperty as KeyEmailOutputProperty;
                    if(emailOutputProperty == null)
                    {
                        return null;
                    }

                    return new KeyEmailHandler(emailOutputProperty.EmailAddresses);

                default:
                    return null;
            }
        }
    }
}
