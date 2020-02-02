using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Models;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class MasterDetailViewModel<T> : BaseViewModel
        where T : class, IModel, new()
    {
        public MasterDetailViewModel(
            IBusyStateRegistry busyStateManager,
            IndexViewModel<T> indexViewModel,
            SelectedItemViewModel<T> selectedItemViewModel) 
            : base(busyStateManager)
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
            var model = new T();
            SelectedItemViewModel.SelectedItem = model;
        }

    }
}