using System;
using System.Collections.ObjectModel;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public abstract class IndexBoundViewModelBase<TModel, TIndex> 
        : ModelBoundViewModelBase<TModel>
        where TModel : Weeks<TIndex>, new()
        where TIndex : ISchedule
    {
        public IndexBoundViewModelBase(IDataGateway dataGateway) : base(dataGateway)
        {
            Index = new ObservableCollection<TIndex>();
        }

        protected override void Initialise()
        {
            base.Initialise();
            if (Index.Count > 0)
            {
                Index.Clear();
            }
            if (ModelObject.Schedules != null)
            {
                foreach (var schedule in ModelObject.Schedules)
                {
                    Index.Add(schedule);
                }
            }
        }

        public ObservableCollection<TIndex> Index { get; set; }
    }
}
