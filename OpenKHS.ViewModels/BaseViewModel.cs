using GalaSoft.MvvmLight;

namespace OpenKHS.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        // TODO use BusyStateManagerStd
        public bool IsBusy { get; set; }

        public virtual bool CanExecute => !IsBusy;
    }
}