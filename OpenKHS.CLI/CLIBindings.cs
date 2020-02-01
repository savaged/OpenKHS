using Ninject.Modules;

namespace OpenKHS.CLI
{
    public class CLIBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IFeedbackService>().To<FeedbackService>()
                .InSingletonScope();
        }
    }
}