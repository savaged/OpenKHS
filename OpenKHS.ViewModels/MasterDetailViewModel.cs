using System;
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

        public virtual void Load()
        {
            IndexViewModel.Load();
        }

        public ICommand AddCmd { get; set; }

        public bool CanAdd => CanExecute;

        protected void OnAdd()
        {
            var model = ModelService.Create<T>();
            SelectedItemViewModel.SelectedItem = model;
        }

    }
}