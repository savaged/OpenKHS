using MvvmDialogs;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public abstract class DialogViewModelBase<T> : ModelBoundViewModelBase<T>, IModalDialogViewModel
        where T : IModel, new()
    {
        private bool? _dialogResult = false;
        private IDialogService _dialogService;

        public DialogViewModelBase(IDialogService dialogService, IDataGatewayFacade<T> dataGatewayFacade)
            : base(dataGatewayFacade)
        {
            _dialogService = dialogService;
        }

        public bool? DialogResult
        {
            get => _dialogResult;
            set => Set(ref _dialogResult, value);
        }
    }
}
