using Ninject.Modules;

namespace OpenKHS.CLI.IoC
{
    public class CoreBindings : NinjectModule
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