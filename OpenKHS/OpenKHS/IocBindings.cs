
using MvvmDialogs;
using OpenKHS.ViewModels;
using OpenKHS.Utils.DataGateway;
using Ninject.Modules;
using OpenKHS.Interfaces;
using OpenKHS.Views;

namespace OpenKHS
{
    internal class IocBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDialogService>().To<DialogService>().InSingletonScope();
            Bind<IDataGateway>().To<DataGateway>().InSingletonScope();

            Bind<IViewManager>().To<MainViewModel>();

            Bind<IManagedView>().To<MainWindow>();

            // Map datacontext using interface
        }
    }
}
