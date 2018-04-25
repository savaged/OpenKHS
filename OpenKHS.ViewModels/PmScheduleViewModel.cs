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
            Chairmen = new ObservableCollection<Friend>();
            WtReaders = new ObservableCollection<Friend>();
            WtConductors = new ObservableCollection<Friend>();
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

            CongMembers.Where(f => f.PmChairman).ToList().ForEach(f => {
                if (!Chairmen.Contains(f)) Chairmen.Add(f);
            });
            CongMembers.Where(f => f.WtReader).ToList().ForEach(f => {
                if (!WtReaders.Contains(f)) WtReaders.Add(f);
            });
            CongMembers.Where(f => f.WtConductor).ToList().ForEach(f => {
                if (!WtConductors.Contains(f)) WtConductors.Add(f);
            });
            if (ModelObject != null && ModelObject.WtConductor == null)
            {
                ModelObject.WtConductor = CongMembers.Where(f => f.MainWtConductor).FirstOrDefault();
            }
        }

        public ObservableCollection<Friend> Chairmen { get; private set; }

        public ObservableCollection<Friend> WtReaders { get; private set; }

        public ObservableCollection<Friend> WtConductors { get; private set; }
    }
}
