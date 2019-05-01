using Ninject.Modules;
using OpenKHS.Data;
using OpenKHS.Interfaces;
using OpenKHS.ViewModels;
using OpenKHS.ViewModels.Utils;
using OpenKHS.Views;

namespace OpenKHS
{
    class IocBindings : NinjectModule
    {
        /// <summary>
        /// Using this in App.cs as a kind of dictionary with interfaces as
        /// the keys and implementations as the values all fully injected.
        /// </summary>
        public override void Load()
        {
            Bind<MessageBoxService>().ToSelf().InSingletonScope();
            Bind<DatabaseContext>().ToSelf().InSingletonScope();
            Bind<IRepositoryLookup>().To<RepositoryLookup>();
            Bind<IMainViewModel>().To<MainViewModel>();
            Bind<IMainView>().To<MainWindow>();
        }
    }
}
