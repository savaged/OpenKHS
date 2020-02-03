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
            set => Set(ref _selectedItem, value);
        }

        public bool IsItemSelected => SelectedItem != null;

        public ICommand SaveCmd { get; }
        public ICommand DeleteCmd { get; }

        public virtual bool CanSave => CanExecute && IsItemSelected;
        public virtual bool CanDelete => CanExecute && IsItemSelected;

        protected virtual void OnSave()
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            if (SelectedItem.IsNew())
            {
                ModelService.Insert(SelectedItem);
            }
            else
            {
                ModelService.Update(SelectedItem);
            }
            MessengerInstance.Send(new BusyMessage(false, this));
        }

        protected virtual void OnDelete()
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            ModelService.Delete(SelectedItem);
            MessengerInstance.Send(new BusyMessage(false, this));
        }

    }
}