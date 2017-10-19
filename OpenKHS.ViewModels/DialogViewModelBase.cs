using MvvmDialogs;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    abstract class DialogViewModelBase : ViewModelBase, IModalDialogViewModel
    {
        public DialogViewModelBase() { }

        public DialogViewModelBase(IDataGateway dataGateway) : base(dataGateway) { }

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
