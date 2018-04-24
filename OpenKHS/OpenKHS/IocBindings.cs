
using MvvmDialogs;
using OpenKHS.ViewModels;
using Ninject.Modules;
using OpenKHS.Interfaces;
using OpenKHS.Views;

namespace OpenKHS
{
    class IocBindings : NinjectModule
    {
        /// <summary>
        /// Using this in App.cs as a kind of dictionary with interfaces as
        /// the keys and implementations as the values all fully injected.
        /// NOTE: The DialogService maps viewmodels into view datacontext.
        /// </summary>
        public override void Load()
        {
            Bind<IDialogService>().To<DialogService>().InSingletonScope();
            Bind<IMainView>().To<MainWindow>();
            Bind<IMainViewModel>().To<MainViewModel>();
            
        }
    }
}
