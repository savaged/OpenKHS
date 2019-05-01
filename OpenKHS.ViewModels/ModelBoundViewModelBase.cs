using OpenKHS.Interfaces;
using System.ComponentModel;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T> : LocalViewModelBase, IModelBoundViewModel<T> 
        where T : IModel, new()
    {
        private T _modelObject;
        protected readonly IRepositoryLookup RepositoryLookup;

        public ModelBoundViewModelBase(IRepositoryLookup repositoryLookup)
        {
            RepositoryLookup = repositoryLookup;
            Repository = (IModelRepository<T>)repositoryLookup?.Repositories[typeof(T)];
        }

        protected IModelRepository<T> Repository { get; }

        protected IModelRepository<R> GetRelatedRepository<R>() where R : IModel, new()
        {
            return RepositoryLookup.GetRelatedRepository<R>();
        }

        protected bool IsDirty { get; set; }

        protected virtual void Initialise(T data)
        {
            if (data == null)
            {
                data = new T();
            }
            ModelObject = data;            
        }

        public T ModelObject
        {
            get => _modelObject;
            set
            {
                if (_modelObject != null)
                {
                    if (value == null)
                    {
                        _modelObject.PropertyChanged -= OnModelObjectPropertyChanged;
                    }
                    Save();
                }
                Set(ref _modelObject, value);
                IsDirty = false;
                if (_modelObject != null)
                {
                    _modelObject.PropertyChanged += OnModelObjectPropertyChanged;
                }
            }
        }

        protected abstract void AddModelObjectToDbContext();

        protected virtual void OnModelObjectPropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            if (ModelObject.IsNew)
            {
                AddModelObjectToDbContext();
            }
            IsDirty = true;
            ModelObjectPropertyChanged.Invoke(this, e);
        }

        protected event PropertyChangedEventHandler ModelObjectPropertyChanged = delegate { };

        public virtual void Save()
        {
            if (ModelObject != null)
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
