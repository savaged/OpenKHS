using System;
using OpenKHS.Interfaces;
using GalaSoft.MvvmLight;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T> : LocalViewModelBase, IModelBoundViewModel<T> 
        where T : IModel, new()
    {
        private T _modelObject;

        public ModelBoundViewModelBase()
        {
        }

        protected void Initialise(T data)
        {
            ModelObject = data;
        }

        public T ModelObject
        {
            get => _modelObject;
            set => Set(ref _modelObject, value);
        }

        public void Save()
        {
            using (var db = new DatabaseContext())
            {
                db.SaveChanges();
            }
        }
    }
}
