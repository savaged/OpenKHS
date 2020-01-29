using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public abstract class SelectedItemViewModel<T> : ModelBoundViewModel
        where T : class, IModel
    {
        private T? _selectedItem;

        public SelectedItemViewModel(
            IDbContextFactory dbContextFactory) 
            : base(dbContextFactory)
        {
        }

        public T? SelectedItem 
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

    }
}