using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Commands
{
    public class RootCommand : ICommand
    {
        private readonly CommandLineApplication _app;

        public static void Configure(CommandLineApplication app)
        {
            app.Name = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;

            app.HelpOption("-? | -h | --help");

            app.Command(Commands.DecryptCommand.CommandName, Commands.DecryptCommand.Configure);
            app.Command(Commands.EncryptCommand.CommandName, Commands.EncryptCommand.Configure);

            app.OnExecute(() =>
            {
                (new RootCommand(app)).Run();

                return 0;
            });
        }

        public RootCommand(CommandLineApplication app)
        {
            _app = app;
        }

        public void Run()
        {
            _app.ShowHelp();
        }
    }
}
