using System;
using OpenKHS.Interfaces;
using GalaSoft.MvvmLight;
using System.Reflection;
using log4net;
using OpenKHS.Facades;
using System.Collections.ObjectModel;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T> : ViewModelBase, IModelBoundViewModel<T>
        where T : IModel, new()
    {
        private T _modelObject;

        private readonly DataGatewayFacade<T> _facade;

        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ModelBoundViewModelBase(IDataGateway dataGateway)
        {
            _facade = new DataGatewayFacade<T>(dataGateway);
        }

        protected void InitialiseAsSingleObject(int id)
        {
            ModelObject = _facade.Show(id);
        }

        protected void InitialiseAsIndex()
        {
            // TODO
        }

        public T ModelObject
        {
            get => _modelObject;
            set => Set(ref _modelObject, value);
        }

        public ObservableCollection<T> Index { get; set; }

        protected virtual void SaveForm()
        {
            _facade.Update(ModelObject);
        }
    }
}
