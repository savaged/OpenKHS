using System.ComponentModel;
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
            CancelCmd = new RelayCommand(OnCancel, () => CanCancel);
            DeleteCmd = new RelayCommand(OnDelete, () => CanDelete);

            PropertyChanged += OnPropertyChanged;
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
        public ICommand CancelCmd { get; }

        public virtual bool CanSave => CanExecute && IsItemSelected;
        public virtual bool CanCancel => CanExecute && IsItemSelected;
        public virtual bool CanDelete => CanExecute && IsItemSelected
            && !IsSelectedItemNew;

        public bool IsSelectedItemNew => SelectedItem?.IsNew != true;

        protected virtual async void OnSave()
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            try
            {
                if (SelectedItem.IsNew())
                {
                    await ModelService.InsertAsync(SelectedItem);
                }
                else
                {
                    await ModelService.UpdateAsync(SelectedItem);
                }
            }
            finally
            {
                MessengerInstance.Send(new BusyMessage(false, this));
            }
        }

        protected virtual async void OnDelete()
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            try
            {
                await ModelService.DeleteAsync(SelectedItem);
            }
            finally
            {
                MessengerInstance.Send(new BusyMessage(false, this));
            }
        }

        protected virtual void OnCancel()
        {
            SelectedItem = null;
        }

        private void OnPropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CanExecute))
            {
                RaisePropertyChanged(nameof(CanSave));
                RaisePropertyChanged(nameof(CanCancel));
                RaisePropertyChanged(nameof(CanDelete));
            }
        }

    }
}