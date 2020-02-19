using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.ViewModels.Messages;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class MasterDetailViewModel<T> : ModelBoundViewModel
        where T : class, IModel, new()
    {
        public MasterDetailViewModel(
            IBusyStateRegistry busyStateManager,
            IModelService modelService,
            IndexViewModel<T> indexViewModel,
            SelectedItemViewModel<T> selectedItemViewModel) 
            : base(busyStateManager, modelService)
        {
            IndexViewModel = indexViewModel ??
                throw new ArgumentNullException(nameof(indexViewModel));
            SelectedItemViewModel = selectedItemViewModel ??
                throw new ArgumentNullException(nameof(selectedItemViewModel));
            
            AddCmd = new RelayCommand(OnAdd, () => CanAdd);

            MessengerInstance.Register<ModelSavedMessage<T>>(this, OnModelSaved);
        }

        public IndexViewModel<T> IndexViewModel { get; }
        public SelectedItemViewModel<T> SelectedItemViewModel { get; }

        public virtual async Task LoadAsync()
        {
            await IndexViewModel.LoadAsync();
        }

        public ICommand AddCmd { get; set; }

        public bool CanAdd => CanExecute;

        protected void OnAdd()
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            try
            {
                var model = ModelService.Create<T>();
                SelectedItemViewModel.SelectedItem = model;
            }
            finally
            {
                MessengerInstance.Send(new BusyMessage(false, this));
            }
        }

        private async void OnModelSaved(ModelSavedMessage<T> m)
        {
            await IndexViewModel.LoadAsync();
        }

    }
}