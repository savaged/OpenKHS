using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Models;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class MasterDetailViewModel<T> : BaseViewModel
        where T : class, IModel
    {
        private readonly IModelFactory _modelFactory;

        public MasterDetailViewModel(
            IBusyStateRegistry busyStateManager,
            IModelFactory modelFactory,
            IndexViewModel<T> indexViewModel,
            SelectedItemViewModel<T> selectedItemViewModel) 
            : base(busyStateManager)
        {
            _modelFactory = modelFactory ??
                throw new ArgumentNullException(nameof(modelFactory));
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
            var model = _modelFactory.Create<T>();
            SelectedItemViewModel.SelectedItem = model;
        }

    }
}