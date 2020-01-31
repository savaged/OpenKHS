using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public abstract class SelectedItemViewModel<T> : ModelBoundViewModel
        where T : class, IModel
    {
        private T? _selectedItem;

        public SelectedItemViewModel(
            IModelService modelService) 
            : base(modelService)
        {
            SaveCmd = new RelayCommand(OnSave, () => CanSave);
        }

        public T? SelectedItem 
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public bool IsItemSelected => SelectedItem != null;

        public ICommand SaveCmd { get; }

        /// <summary>
        /// The sub-class can override this
        /// </summary>
        public virtual bool CanSave => false;

        protected virtual void OnSave()
        {
            // The sub-class can add the behaviour
        }

    }
}