using MvvmDialogs;

namespace OpenKHS.ViewModels
{
    public abstract class DialogViewModelBase : ViewModelBase, IModalDialogViewModel
    {
        private bool? _dialogResult = false;

        public bool? DialogResult
        {
            get => _dialogResult;
            set
            {
                _dialogResult = value;
                NotifyPropertyChanged();
            }
        }
    }
}
