using System;
using GalaSoft.MvvmLight;
using OpenKHS.Interfaces;
using OpenKHS.ViewModels.Utils;

namespace OpenKHS.ViewModels
{
    public abstract class LocalViewModelBase : ViewModelBase
    {
        public IViewState GlobalViewState => ViewState.Default;

        public virtual bool CanExecute => GlobalViewState.IsNotBusy;
    }
}
