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
                if (_modelObject != null && value == null)
                {
                    ModelObject.PropertyChanged -= OnModelObjectPropertyChanged;
                }
                Set(ref _modelObject, value);
                IsDirty = false;
                if (_modelObject != null)
                {
                    if (_modelObject.IsNew)
                    {
                        AddModelObjectToDbContext();
                    }
                    _modelObject.PropertyChanged += OnModelObjectPropertyChanged;
                }
            }
        }

        protected abstract void AddModelObjectToDbContext();

        private void OnModelObjectPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsDirty = true;
        }

        public virtual void Save()
        {
            if (ModelObject != null)
            {
                if (IsDirty)
                {
                    DbContext.Save();
                    IsDirty = false;
                }
            }
        }
    }
}
