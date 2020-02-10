using System;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        public BaseViewModel(
            IBusyStateRegistry busyStateManager)
        {
            IsBusy = false;
            BusyStateManager = busyStateManager ??
                throw new ArgumentNullException(nameof(busyStateManager));
        }

        public IBusyStateRegistry BusyStateManager { get; }

        public bool IsBusy { get; private set; }

        public bool IsNotBusy => !IsBusy;

        public virtual bool CanExecute => IsNotBusy;

        protected void SetIsBusy(bool value, object sender)
        {
            if (sender?.GetType() == typeof(MainViewModel) && IsBusy != value)
            {
                IsBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
                RaisePropertyChanged(nameof(IsNotBusy));
                RaisePropertyChanged(nameof(CanExecute));
            }
        }
    }
}