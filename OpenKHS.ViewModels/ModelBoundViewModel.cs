using System;
using GalaSoft.MvvmLight;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModel : ViewModelBase
    {
        protected IDbContextFactory DbContextFactory { get; }

        public ModelBoundViewModel(IDbContextFactory dbContextFactory)
        {
            DbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

    }
}