using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Data;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ScheduleViewModelBase<PmSchedule>
    {
        public PmScheduleViewModel(IRepositoryLookup repositoryLookup, IList<LocalCongregationMember> congMembers)
            : base(repositoryLookup, congMembers)
        {
            WtReaders = new List<LocalCongregationMember>();
            WtConductors = new List<LocalCongregationMember>();
            PublicTalks = new List<PublicTalk>();
            LoadLookups();
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

            PublicTalks.Clear();
            GetRelatedRepository<PublicTalk>().Index().ToList()
                .ForEach(p => PublicTalks.Add(p));

            SetDefaultWtConductor();
        }

        private void SetDefaultWtConductor()
        {
            if (ModelObject != null && ModelObject.WtConductor == null)
            {
                ModelObject.WtConductor = CongMembers.Where(f => f.MainWtConductor).FirstOrDefault();
            }
        }

        protected override void New()
        {
            base.New();
            SetDefaultWtConductor();
        }

        public List<LocalCongregationMember> WtReaders { get; private set; }

        public List<LocalCongregationMember> WtConductors { get; private set; }

        public List<PublicTalk> PublicTalks { get; private set; }
    }
}
