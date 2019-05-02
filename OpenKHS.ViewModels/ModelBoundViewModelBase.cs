using OpenKHS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T> : LocalViewModelBase, IModelBoundViewModel<T> 
        where T : IModel, new()
    {
        private T _selected;
        protected readonly IDictionary<Type, object> Repositories;

        public ModelBoundViewModelBase(IRepositoryLookup repositoryLookup)
        {
            Repository = (IModelRepository<T>)repositoryLookup.Repositories[typeof(T)];
        }

        protected IModelRepository<T> Repository { get; }

        protected IModelRepository<R> GetRelatedRepository<R>() where R : IModel, new()
        {
            return (IModelRepository<R>)Repositories[typeof(R)];
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

        public T Selected
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
