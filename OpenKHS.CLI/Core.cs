using Ninject;
using CommandLine;
using OpenKHS.Data.StaticData;
using OpenKHS.CLI.Modules;
using System;
using OpenKHS.CLI.CommandLineOptions;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.CLI
{
    class Core
    {
        private readonly IKernel _kernel;
        private readonly string[] _args;
        private readonly IModule _listModule;
        private readonly IModule _addModule;

        public Core(string[] args)
        {
            _args = args;

            _kernel = new StandardKernel(
                new CLIBindings(),
                new ViewModelCoreBindings(),
                new DbContextBindings(DbConnectionStrings.LIVE));

            _listModule = _kernel.Get<ListModule>() ??
                throw new InvalidOperationException("Missing dependency!");

            _addModule = _kernel.Get<AddModule>() ??
                throw new InvalidOperationException("Missing dependency!");
        }

        public int Run()
        {
            IModule module = new NullModule();
            var entity = string.Empty;
            var exitCode = Parser.Default
                .ParseArguments<ListOptions, AddOptions>(_args)
                .MapResult(
                    (ListOptions opt) => 
                    {
                        entity = string.Empty;
                        if (opt.IsAssignmentType)
                        {
                            entity = nameof(AssignmentType);
                        }
                        else
                        {
                            GetEntityFromOption(opt);
                        }
                        module = _listModule;
                        return 0;
                    },
                    (AddOptions opt) => 
                    {
                        var entity = GetEntityFromOption(opt);
                        module = _addModule;
                        return 0;
                    },
                    _ => 1);
            module.Load(entity);
            return exitCode;
        }

        private string GetEntityFromOption(EntityOptions opt)
        {
            var entity = nameof(LocalCongregationMember);
            if (opt.IsAssignment)
            {
                entity = nameof(Assignment);
            }
            else if (opt.IsClmmSchedule)
            {
                entity = nameof(ClmmSchedule);
            }
            return entity;
        }
        
    }
}
