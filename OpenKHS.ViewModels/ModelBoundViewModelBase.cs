using System;
using OpenKHS.Interfaces;
using OpenKHS.Data;
using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModelBase<T> : LocalViewModelBase, IModelBoundViewModel<T> 
        where T : IModel, new()
    {
        private T _modelObject;
        private IDictionary<Type, object> repos;

        public ModelBoundViewModelBase(DatabaseContext dbContext)
        {
            repos = new Dictionary<Type, object>
            {
                { typeof(Friend), new FriendRepository(dbContext) },
                { typeof(PmSchedule), new PmScheduleRepository(dbContext) },
                { typeof(ClmmSchedule), new ClmmScheduleRepository(dbContext) }
            };
            DbContext = (IModelRepository<T>)repos[typeof(T)];
        }

        protected IModelRepository<T> DbContext { get; }

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
            DbContext.Update(ModelObject);
        }
    }
}
