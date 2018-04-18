using System;
using OpenKHS.Interfaces;
using GalaSoft.MvvmLight;
using OpenKHS.Facades;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T>
        : ViewModelBase, IModelBoundViewModel<T> 
        where T : IModel, new()
    {
        private T _modelObject;

        private readonly DataGatewayFacade<T> _facade;

        public ModelBoundViewModelBase(IDataGateway dataGateway)
        {
            _facade = new DataGatewayFacade<T>(dataGateway);
        }

        protected virtual void Initialise()
        {
            ModelObject = _facade.Show();
        }

        public T ModelObject
        {
            get => _modelObject;
            set => Set(ref _modelObject, value);
        }

        public virtual void SaveModelObject()
        {
            _facade.Update(ModelObject);
        }
    }
}
