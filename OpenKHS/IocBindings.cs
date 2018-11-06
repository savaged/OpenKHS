﻿using Ninject.Modules;
using OpenKHS.ViewModels;
using OpenKHS.Interfaces;
using OpenKHS.Views;
using OpenKHS.Data;

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
            Bind<IMainView>().To<MainWindow>();
            Bind<IMainViewModel>().To<MainViewModel>();
            Bind<DatabaseContext>().ToSelf().InSingletonScope();
        }
    }
}
