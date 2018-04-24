using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public abstract class IndexBoundViewModelBase<T> : ModelBoundViewModelBase<T>, IIndexBoundViewModel<T> 
        where T : IModel, new()
    {
        public IndexBoundViewModelBase()
        {
            Index = new ObservableCollection<T>();
        }

        protected void Initialise(IList<T> data)
        {
            if (Index.Count > 0)
            {
                Index.Clear();
            }
            foreach (var item in data)
            {
                Index.Add(item);
            }
            Initialise(data.FirstOrDefault());
        }

        public ObservableCollection<T> Index { get; set; }

        public T SelectedItem
        {
            get => ModelObject;
            set
            {
                ModelObject = value;
                RaisePropertyChanged(nameof(SelectedItem));
                RaisePropertyChanged(nameof(IsItemSelected));
            }
        }

        public virtual bool IsItemSelected => SelectedItem != null;
    }
}
