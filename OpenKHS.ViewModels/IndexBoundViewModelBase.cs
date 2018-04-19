using System;
using System.Collections.ObjectModel;
using OpenKHS.Data;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public abstract class IndexBoundViewModelBase<T> : ModelBoundViewModelBase<T>
        where T : IModel, new()
    {
        private T _selectedItem;

        public IndexBoundViewModelBase()
        {
            Index = new ObservableCollection<T>();
        }

        protected override void Initialise()
        {
            base.Initialise();
            if (Index.Count > 0)
            {
                Index.Clear();
            }
            using (var dbContext = new DatabaseContext())
            {
                // TODO
            }
        }

        public ObservableCollection<T> Index { get; set; }

        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                RaisePropertyChanged(nameof(IsItemSelected));
            }
        }

        public bool IsItemSelected => SelectedItem != null;

        public override void Save()
        {
            // TODO
        }
    }
}
