using System;
using OpenKHS.Interfaces;
using GalaSoft.MvvmLight;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T> : ViewModelBase, IModelBoundViewModel<T> 
        where T : IModel, new()
    {
        private T _modelObject;

        public ModelBoundViewModelBase()
        {
        }

        protected virtual void Initialise()
        {
            // TODO Load ModelObject 
        }

        public T ModelObject
        {
            get => _modelObject;
            set => Set(ref _modelObject, value);
        }

        public virtual void Save()
        {
            // TODO Save model object
        }
    }
}
