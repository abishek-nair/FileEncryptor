using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Commands
{
    public class DecryptCommand : ICommand
    {
        private readonly CommandOption _fileWriteOpt;

        public static string CommandName = "decrypt";

        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Decrypts the message";
            command.HelpOption("-? | -h | --help");

            CommandOption fileWriteOpt = command.Option(
                "-o | --output <filename>",
                "File name to store decrypted file into",
                CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                (new DecryptCommand(fileWriteOpt)).Run();

                return 0;
            });
        }

        public DecryptCommand(CommandOption fileWriteOpt)
        {
            _fileWriteOpt = fileWriteOpt;
        }

        public void Run()
        {
            if(_fileWriteOpt.HasValue())
            {
                Console.WriteLine($"Write to {_fileWriteOpt.Value()}");
            }
            else
            {
                Console.WriteLine("Writing to Stdout");
            }
        }
    }
}
