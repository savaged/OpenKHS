using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ScheduleViewModelBase<PmSchedule>
    {
        public PmScheduleViewModel(DatabaseContext dbContext, IList<Friend> congMembers)
            : base(dbContext, congMembers) { }

        protected override PmSchedule GetDefaultSchedule(DateTime weekStarting)
        {
            return DbContext.Index().SingleOrDefault(s => s.WeekStarting == weekStarting);
        }

        protected override void AddModelObjectToDbContext() { if (IsValidSchedule()) DbContext.Store(ModelObject); }

        protected override void LoadLookups(IList<Friend> congMembers)
        {
            base.LoadLookups(congMembers);
            Chairmen = congMembers.Where(f => f.PmChairman).ToList();
            WtReaders = congMembers.Where(f => f.WtReader).ToList();
            WtConductors = congMembers.Where(f => f.WtConductor).ToList();
            if (ModelObject != null && ModelObject.WtConductor == null)
            {
                ModelObject.WtConductor = congMembers.Where(f => f.MainWtConductor).FirstOrDefault();
            }
        }

        public IList<Friend> Chairmen { get; private set; }

        public IList<Friend> WtReaders { get; private set; }

        public IList<Friend> WtConductors { get; private set; }
    }
}
