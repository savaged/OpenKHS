using System;
using GalaSoft.MvvmLight;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        public BaseViewModel(
            IBusyStateRegistry busyStateManager)
        {
            BusyStateManager = busyStateManager ??
                throw new ArgumentNullException(nameof(busyStateManager));
        }

        public IBusyStateRegistry BusyStateManager { get; }
        
        public bool IsBusy => BusyStateManager.IsBusy;

        public virtual bool CanExecute => !IsBusy;
    }
}