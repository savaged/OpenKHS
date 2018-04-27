using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Data;
using System.Collections.ObjectModel;
using OpenKHS.Models.Utils;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ScheduleViewModelBase<PmSchedule>
    {
        public PmScheduleViewModel(DatabaseContext dbContext, IList<Friend> congMembers)
            : base(dbContext, congMembers)
        {
            Chairmen = new List<Friend>();
            WtReaders = new List<Friend>();
            WtConductors = new List<Friend>();
            LoadLookups();
        }

        protected override void AddModelObjectToDbContext()
        {
            if (IsValidSchedule())
            {
                DbContext.Store(ModelObject);
            }
        }

        protected override void LoadLookups()
        {
            base.LoadLookups();

            Chairmen.Clear();
            CongMembers.Where(f => f.PmChairman).ToList().ForEach(f => Chairmen.Add(f));
            Chairmen = Chairmen.OrderBy(f => f.PmAssignmentTally).ToList();
            RaisePropertyChanged(nameof(Chairmen));

            WtReaders.Clear();
            CongMembers.Where(f => f.WtReader).ToList().ForEach(f => WtReaders.Add(f));
            WtReaders = WtReaders.OrderBy(f => f.PmAssignmentTally).ToList();
            RaisePropertyChanged(nameof(WtReaders));

            WtConductors.Clear();
            CongMembers.Where(f => f.WtConductor).ToList().ForEach(f => WtConductors.Add(f));
            WtConductors = WtConductors.OrderBy(f => f.PmAssignmentTally).ToList();
            RaisePropertyChanged(nameof(WtConductors));

            if (ModelObject != null && ModelObject.WtConductor == null)
            {
                ModelObject.WtConductor = CongMembers.Where(f => f.MainWtConductor).FirstOrDefault();
            }
        }

        public List<Friend> Chairmen { get; private set; }

        public List<Friend> WtReaders { get; private set; }

        public List<Friend> WtConductors { get; private set; }
    }
}
