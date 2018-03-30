using MvvmDialogs;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public abstract class DialogViewModelBase<T> : ModelBoundViewModelBase<T>, IModalDialogViewModel
        where T : IModel, new()
    {
        private bool? _dialogResult = false;

        public bool? DialogResult
        {
            get => _dialogResult;
            set => Set(ref _dialogResult, value);
        }
    }
}
