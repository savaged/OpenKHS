using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.Models.Utils;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class SelectedItemViewModel<T> : ModelBoundViewModel
        where T : class, IModel
    {
        private T? _selectedItem;

        public SelectedItemViewModel(
            IBusyStateRegistry busyStateManager,
            IModelService modelService) 
            : base(busyStateManager, modelService)
        {
            SaveCmd = new RelayCommand(OnSave, () => CanSave);
            DeleteCmd = new RelayCommand(OnDelete, () => CanDelete);
        }

        public T? SelectedItem 
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                RaisePropertyChanged(nameof(IsItemSelected));
                RaisePropertyChanged(nameof(SelectedItemName));
            } 
        }

        public bool IsItemSelected => SelectedItem != null;

        public string? SelectedItemName => SelectedItem?.GetType()?.Name;

        public ICommand SaveCmd { get; }
        public ICommand DeleteCmd { get; }

        public virtual bool CanSave => CanExecute && IsItemSelected;
        public virtual bool CanDelete => CanExecute && IsItemSelected;

        protected virtual async void OnSave()
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            if (SelectedItem.IsNew())
            {
                await ModelService.InsertAsync(SelectedItem);
            }
            else
            {
                await ModelService.UpdateAsync(SelectedItem);
            }
            MessengerInstance.Send(new BusyMessage(false, this));
        }

        protected virtual async void OnDelete()
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            await ModelService.DeleteAsync(SelectedItem);
            MessengerInstance.Send(new BusyMessage(false, this));
        }

    }
}