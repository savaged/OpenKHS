using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.Models.Utils;

namespace OpenKHS.ViewModels
{
    public class SelectedItemViewModel<T> : ModelBoundViewModel
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

        public virtual bool CanSave => CanExecute && IsItemSelected;

        protected virtual void OnSave()
        {
            if (SelectedItem.IsNew())
            {
                ModelService.Insert(SelectedItem);
            }
            else
            {
                ModelService.Update(SelectedItem);
            }
        }

    }
}