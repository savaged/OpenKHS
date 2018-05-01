using System;
using OpenKHS.Interfaces;
using OpenKHS.Data;
using System.Collections.Generic;
using OpenKHS.Models;
using System.ComponentModel;

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
                { typeof(ClmmSchedule), new ClmmScheduleRepository(dbContext) },
                { typeof(PublicTalk), new PublicTalkRepository(dbContext) }
            };
            Repository = (IModelRepository<T>)repos[typeof(T)];
        }

        protected IModelRepository<T> Repository { get; }

        protected IModelRepository<R> GetRelatedRepository<R>() where R : IModel, new()
        {
            return (IModelRepository<R>)repos[typeof(R)];
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
                if (_modelObject != null && value == null)
                {
                    _modelObject.PropertyChanged -= OnModelObjectPropertyChanged;
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

        private void OnModelObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
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
