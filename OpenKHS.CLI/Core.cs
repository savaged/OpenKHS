using Ninject;
using CommandLine;
using OpenKHS.Data.StaticData;
using OpenKHS.CLI.Modules;
using System;
using OpenKHS.CLI.CommandLineOptions;
using OpenKHS.Models;
using System.Threading.Tasks;
using OpenKHS.ViewModels;

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
                new ViewModelCoreBindings(),
                new DbContextBindings(DbConnectionStrings.LIVE));

            _listModule = _kernel.Get<ListModule>() ??
                throw new InvalidOperationException("Missing dependency!");
        }

        public async Task<int> RunAsync()
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
                        // TODO module = _addModule;
                        return 0;
                    },
                    _ => 1);
            await module.LoadAsync(entity);
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
