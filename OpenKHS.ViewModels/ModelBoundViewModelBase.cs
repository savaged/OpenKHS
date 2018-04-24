using System;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T> : LocalViewModelBase, IModelBoundViewModel<T> 
        where T : IModel, new()
    {
        private T _modelObject;

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
            set => Set(ref _modelObject, value);
        }

        public virtual void Save()
        {
            if (ModelObject == null)
            {
                throw new ArgumentNullException("Model object should be set prior to Save");
            }
            if (ModelObject.IsNew)
            {
                //DataGatewayFacade.Store(ModelObject);
            }
            else
            {
                //DataGatewayFacade.Update(ModelObject);
            }
        }
    }
}
