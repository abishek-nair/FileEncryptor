using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;

namespace FileEncryptor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var commandLineApplication = SetupCommandLineOptions();
            commandLineApplication.OnExecute(() =>
            {
                
            });
        }

        private static CommandLineApplication SetupCommandLineOptions()
        {
            var commandLineApplication = new CommandLineApplication(throwOnUnexpectedArg: false);

            CommandOption encryptOpt = commandLineApplication.Option(
                "-e|--encrypt",
                "Command: Encrypt - encrypts the file or input stream",
                CommandOptionType.NoValue);

            CommandOption decryptOpt = commandLineApplication.Option(
                "-d|--decrypt",
                "Command: Decrypt - decrypts the file or input stream",
                CommandOptionType.NoValue);

            CommandOption passphraseWriteOpt = commandLineApplication.Option(
                "-w|--write <filename>",
                "Write passphrase into file",
                CommandOptionType.SingleValue);

            CommandOption fileWriteOpt = commandLineApplication.Option(
                "-o|--output <filename>",
                "File name to store decrypted file into",
                CommandOptionType.SingleValue);

            CommandOption passphraseEmailOpt = commandLineApplication.Option(
                "-m|--email",
                "Email address(es) to send the passphrase to",
                CommandOptionType.MultipleValue);

            commandLineApplication.HelpOption("-?|-h|--help");

            return commandLineApplication;
        }
    }
}
