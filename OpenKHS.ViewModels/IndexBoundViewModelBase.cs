using System;
using System.Collections.ObjectModel;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public abstract class IndexBoundViewModelBase<T>
        : ModelBoundViewModelBase<T>
        where T : IModel, new()
    {
        private T _selectedItem;

        public IndexBoundViewModelBase(IDataGateway dataGateway) : base(dataGateway)
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
            // TODO load index
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

        public override void SaveModelObject()
        {
            // TODO
        }
    }
}
