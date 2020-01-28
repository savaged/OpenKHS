using Ninject.Modules;

namespace OpenKHS.CLI.IoC
{
    public class CoreBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IFeedbackService>().To<FeedbackService>()
                .InSingletonScope();
        }
    }
}