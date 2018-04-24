using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public abstract class IndexBoundViewModelBase<T> : ModelBoundViewModelBase<T>
        where T : IModel, new()
    {
        public IndexBoundViewModelBase(IDataGatewayFacade<T> dataGatewayFacade) : base(dataGatewayFacade)
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
        }

        public ObservableCollection<T> Index { get; set; }

        public T SelectedItem
        {
            get => ModelObject;
            set
            {
                base.Save();
                ModelObject = value;
                RaisePropertyChanged(nameof(SelectedItem));
                RaisePropertyChanged(nameof(IsItemSelected));
            }
        }

        public virtual bool IsItemSelected => SelectedItem != null;

        public override void Save()
        {
            throw new NotImplementedException("Saving is expected on a single model object");
        }
    }
}
