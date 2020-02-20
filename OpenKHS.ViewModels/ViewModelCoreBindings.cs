using Ninject.Modules;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class ViewModelCoreBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IBusyStateRegistry>().To<BusyStateRegistry>()
                .InSingletonScope();
            Bind<IPotentialAssignmentsFactory>().To<PotentialAssignmentsFactory>()
                .InSingletonScope();
        }
    }
}