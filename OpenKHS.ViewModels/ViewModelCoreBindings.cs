using Ninject.Modules;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class ViewModelCoreBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IModelFactory>().To<ModelFactory>()
                .InSingletonScope();
            Bind<IBusyStateRegistry>().To<BusyStateRegistry>()
                .InSingletonScope();
        }
    }
}