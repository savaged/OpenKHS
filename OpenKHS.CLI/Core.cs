using Ninject;
using CommandLine;
using OpenKHS.Data.StaticData;
using OpenKHS.CLI.Modules;
using System;

namespace OpenKHS.CLI
{
    class Core
    {
        private readonly IKernel _kernel;
        private readonly string[] _args;
        private readonly IModule _listModule;

        public Core(string[] args)
        {
            _args = args;

            _kernel = new StandardKernel(
                new CLIBindings(),
                new DbContextBindings(DbConnectionStrings.LIVE));

            _listModule = _kernel.Get<ListModule>() ??
                throw new InvalidOperationException("Missing dependency!");
        }

        public int Run()
        {
            var exitCode = Parser.Default
                .ParseArguments<CommandLineOptions>(_args)
                .MapResult(
                    (CommandLineOptions o) => 
                    {
                        var verb = o.Verb;
                        var entity = o.Entity;
                        switch (verb)
                        {
                            // TODO add verb cases
                            default:
                                _listModule.Load(entity);
                                break;
                        };
                        return 0;
                    },
                    _ => 1);
            return exitCode;
        }
        
    }
}