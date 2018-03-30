using System;
using OpenKHS.Interfaces;
using GalaSoft.MvvmLight;
using System.Reflection;
using log4net;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T> : ViewModelBase, IModelBoundViewModel<T>
        where T : IModel, new()
    {
        private T _modelObject;

        protected static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public T ModelObject
        {
            get => _modelObject;
            set => Set(ref _modelObject, value);
        }
    }
}
