using System;
using System.Collections.Generic;
using System.ComponentModel;

using OpenKHS.Interfaces;
using OpenKHS.ViewModels.Utils;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T> : LocalViewModelBase, IModelBoundViewModel<T> 
        where T : IModel, new()
    {
        private T _selected;

        public ModelBoundViewModelBase()
        {
        }

        protected IModelRepository<T> Repository { get; }

        protected IModelRepository<R> GetRelatedRepository<R>() 
            where R : IModel, new()
        {
            var value = RepositoryLookup.Default.GetRelatedRepository<R>();
            return value;
        }

        protected bool IsDirty { get; set; }

        protected virtual void Initialise(T data)
        {
            if (data == null)
            {
                data = new T();
            }
            Selected = data;            
        }

        public virtual T Selected
        {
            get => _selected;
            set
            {
                if (_selected != null)
                {
                    if (value == null)
                    {
                        _selected.PropertyChanged -= OnModelObjectPropertyChanged;
                    }
                    Save();
                }
                Set(ref _selected, value);
                IsDirty = false;
                if (_selected != null)
                {
                    _selected.PropertyChanged += OnModelObjectPropertyChanged;
                }
            }
        }

        protected abstract void AddModelObjectToDbContext();

        protected virtual void OnModelObjectPropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            if (Selected.IsNew)
            {
                AddModelObjectToDbContext();
            }
            IsDirty = true;
            ModelObjectPropertyChanged.Invoke(this, e);
        }

        protected event PropertyChangedEventHandler ModelObjectPropertyChanged = delegate { };

        public virtual void Save()
        {
            if (Selected != null)
            {
                if (IsDirty)
                {
                    Repository.Save();
                    IsDirty = false;
                }
            }
        }
    }
}
