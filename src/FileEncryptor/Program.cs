using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;
using System.IO;
using System.Text;
using FileEncryptor.Models;
using FileEncryptor.Engine;

namespace FileEncryptor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: false);

            Commands.RootCommand.Configure(app);

            try
            {
                app.Execute(args);
            }
            catch(CommandParsingException cmdParseException)
            {
                app.ShowHelp(cmdParseException.Command.Name);
            }
        }
    }
}
