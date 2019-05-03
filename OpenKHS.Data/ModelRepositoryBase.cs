using System;

using OpenKHS.Interfaces;

namespace OpenKHS.Data
{
    public class ModelRepositoryBase
    {
        protected readonly DatabaseContext DbContext;        

        public ModelRepositoryBase(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        protected void ValidateStore(IModel @new)
        {
            if (!@new.IsNew)
            {
                throw new ArgumentException(
                    "Trying to add an existing model object as new. " +
                    "Use Update instead.");
            }
        }

        public void Save()
        {
            var count = DbContext.SaveChanges();
            //Log.Debug($"Saved {count} model objects.");
        }
    }
}
