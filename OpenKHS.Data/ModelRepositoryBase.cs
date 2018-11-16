using System;
using System.Reflection;
using log4net;
using OpenKHS.Interfaces;

namespace OpenKHS.Data
{
    public class ModelRepositoryBase
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            Log.Debug($"Saved {count} model objects.");
        }
    }
}
