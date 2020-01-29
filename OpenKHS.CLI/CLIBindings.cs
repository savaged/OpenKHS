using Ninject.Modules;

namespace OpenKHS.CLI
{
    public class CLIBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<CommandLineOptions>().ToSelf()
                .InSingletonScope();
            Bind<IFeedbackService>().To<FeedbackService>()
                .InSingletonScope();
        }
    }
}