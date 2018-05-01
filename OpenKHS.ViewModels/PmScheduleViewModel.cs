using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ScheduleViewModelBase<PmSchedule>
    {
        private ICommand _addPublicTalkCmd;

        public PmScheduleViewModel(DatabaseContext dbContext, IList<CongregationMember> congMembers)
            : base(dbContext, congMembers)
        {
            Chairmen = new List<CongregationMember>();
            WtReaders = new List<CongregationMember>();
            WtConductors = new List<CongregationMember>();
            PublicTalks = new List<PublicTalk>();
            LoadLookups();
            _addPublicTalkCmd = new RelayCommand(OnAddPublicTalk, () => CanExecute);
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
            GetRelatedRepository<PublicTalk>().Index().ToList().ForEach(p => PublicTalks.Add(p));

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

        public List<CongregationMember> Chairmen { get; private set; }

        public List<CongregationMember> WtReaders { get; private set; }

        public List<CongregationMember> WtConductors { get; private set; }

        public List<PublicTalk> PublicTalks { get; private set; }

        public ICommand AddPublicTalkCmd => _addPublicTalkCmd;

        private void OnAddPublicTalk()
        {
            throw new NotImplementedException();
            // TODO open dialog
        }
    }
}
