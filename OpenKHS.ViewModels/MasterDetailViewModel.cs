using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Data;
using OpenKHS.Models;
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
        }

        public IndexViewModel<T> IndexViewModel { get; }
        public SelectedItemViewModel<T> SelectedItemViewModel { get; }

        public virtual async Task LoadAsync()
        {
            await IndexViewModel.LoadAsync();
        }

        public ICommand AddCmd { get; set; }

        public bool CanAdd => CanExecute;

        protected async void OnAdd()
        {
            var model = await ModelService.CreateAsync<T>();
            SelectedItemViewModel.SelectedItem = model;
        }

    }
}