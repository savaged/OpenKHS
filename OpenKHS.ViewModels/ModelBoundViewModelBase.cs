using System;
using OpenKHS.Interfaces;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T> : LocalViewModelBase, IModelBoundViewModel<T> 
        where T : IModel, new()
    {
        private T _modelObject;

        public ModelBoundViewModelBase()
        {
            DbContext = new DatabaseContext();
        }

        protected DatabaseContext DbContext { get; }

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
                Set(ref _modelObject, value);
                if (_modelObject != null && _modelObject.IsNew)
                {
                    AddModelObjectToDbContext();
                }
            }
        }
        protected abstract void AddModelObjectToDbContext();

        public virtual void Save()
        {
            if (ModelObject == null)
            {
                throw new ArgumentNullException("Model object should be initialised prior to Save");
            }
            DbContext.SaveChanges();
        }
    }
}
