using System;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModel : BaseViewModel
    {
        protected IDbContextFactory DbContextFactory { get; }

        public ModelBoundViewModel(IDbContextFactory dbContextFactory)
        {
            DbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

    }
}