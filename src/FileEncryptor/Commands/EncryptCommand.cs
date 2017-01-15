using FileEncryptor.Engine;
using FileEncryptor.Models;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Commands
{
    public class EncryptCommand : ICommand
    {
        private readonly CommandOption _fileInputOpt;
        private readonly CommandOption _passphraseWriteOpt;
        private readonly CommandOption _passphraseEmailOpt;

        public static string CommandName = "encrypt";

        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Encrypts the file or input";
            command.HelpOption("-?|-h|--help");

            CommandOption passphraseWriteOpt = command.Option(
                "-w | --write <filename>",
                "Write passphrase into file",
                CommandOptionType.SingleValue);

            CommandOption fileInputOpt = command.Option(
                "-i | --input",
                "File to encrypt",
                CommandOptionType.MultipleValue);

            CommandOption passphraseEmailOpt = command.Option(
                "-m | --email",
                "Email address(es) to send the passphrase to",
                CommandOptionType.MultipleValue);

            command.OnExecute(() =>
            {
                (new EncryptCommand(fileInputOpt, passphraseWriteOpt, passphraseEmailOpt)).Run();

                return 0;
            });
        }

        public EncryptCommand(CommandOption fileInputOpt, CommandOption passphraseWriteOpt, CommandOption passphraseEmailOpt)
        {
            _fileInputOpt = fileInputOpt;

            _passphraseEmailOpt = passphraseEmailOpt;

            _passphraseWriteOpt = passphraseWriteOpt;
        }

        public void Run()
        {
            var encryptionTaskProperty = ConstructEncryptionProperties(_fileInputOpt, _passphraseWriteOpt, _passphraseEmailOpt);

            var messageFetcher = MessageFetcherFactory.GetMessageFetcher(encryptionTaskProperty);

            var outputHandler = KeyOutputHandlerFactory.GetOutputHandler(encryptionTaskProperty);

            var encryptionManager = new EncryptionManager(encryptionTaskProperty, messageFetcher, outputHandler);

            encryptionManager.Encrypt();
        }

        private static EncryptionTaskProperty ConstructEncryptionProperties(CommandOption fileInputOpt, CommandOption passphraseWriteOpt, CommandOption passphraseEmailOpt)
        {
            InputType inputType;
            KeyOutputType keyOutputType;
            IMessageInputProperty messageInputProperty = null;
            IKeyOutputProperty keyOutputProperty = null;

            if (fileInputOpt.HasValue())
            {
                inputType = InputType.File;
                var inputFileNames = fileInputOpt.Values;
                messageInputProperty = new FileInputProperty(inputFileNames);
            }
            else
            {
                inputType = InputType.StdIn;
                messageInputProperty = new RawInputProperty();
            }

            if (passphraseWriteOpt.HasValue())
            {
                keyOutputType = KeyOutputType.File;

                string passphraseFileName = passphraseWriteOpt.Value();
                if (string.IsNullOrEmpty(passphraseFileName))
                {
                    return null;
                }

                keyOutputProperty = new KeyFileOutputProperty(passphraseFileName);
            }
            else if (passphraseEmailOpt.HasValue())
            {
                keyOutputType = KeyOutputType.Email;

                var emailAddressList = passphraseEmailOpt.Values;
                if (emailAddressList == null || emailAddressList.Count == 0)
                {
                    return null;
                }

                keyOutputProperty = new KeyEmailOutputProperty(emailAddressList);
            }
            else
            {
                keyOutputType = KeyOutputType.StdOut;
            }

            var encryptionTaskProperty = new EncryptionTaskProperty(inputType, keyOutputType, messageInputProperty, keyOutputProperty);

            return encryptionTaskProperty;
        }
    }
}
