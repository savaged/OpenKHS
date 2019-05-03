using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using OpenKHS.Models.Utils;

using Windows.ApplicationModel.DataTransfer;

namespace OpenKHS.ViewModels
{
    public abstract class ScheduleViewModelBase<T> : IndexBoundViewModelBase<T>
        where T : ISchedule, new()
    {
        public ScheduleViewModelBase(IList<LocalCongregationMember> congMembers)
        {
            CongMembers = congMembers;
            Attendants = new List<LocalCongregationMember>();
            Security = new List<LocalCongregationMember>();
            Sound = new List<LocalCongregationMember>();
            Platform = new List<LocalCongregationMember>();
            RovingMic = new List<LocalCongregationMember>();
            Chairmen = new List<LocalCongregationMember>();

            var weekStarting = WeekNumberAdapter.GetFirstDateOfWeekIso8601(DateTime.Now);
            Initialise(Repository.Index(), GetDefaultSchedule(weekStarting));

            CopyToClipboardCmd = new RelayCommand(OnCopyToClipboard, () => CanCopyToClipboard);

            PropertyChanged += OnPropertyChanged;
            ModelObjectPropertyChanged += OnScheduleModelObjectPropertyChanged;
        }

        public override void Cleanup()
        {
            PropertyChanged -= OnPropertyChanged;
            ModelObjectPropertyChanged -= OnScheduleModelObjectPropertyChanged;            
            base.Cleanup();
        }

        public void Load()
        {
            LoadLookups();
        }

        public RelayCommand CopyToClipboardCmd { get; }

        protected IList<LocalCongregationMember> CongMembers { get; private set; }

        protected T GetDefaultSchedule(DateTime weekStarting)
        {
            var defaultSchedule = Repository.Index().SingleOrDefault(s => s.WeekStarting == weekStarting);
            if (defaultSchedule == null)
            {
                defaultSchedule = new T();
            }
            if (defaultSchedule.WeekStarting == DateTime.MinValue)
            {
                defaultSchedule.WeekStarting = WeekNumberAdapter.GetFirstDateOfWeekIso8601(DateTime.Now);
            }
            return defaultSchedule;
        }

        protected override void New()
        {
            var @new = new T();
            SetWeekStartingDate(@new);
            Index.Add(@new);
            Selected = @new;
        }

        protected virtual void LoadLookups()
        {
            Attendants.Clear();
            CongMembers.Where(f => f.Attendant).ToList().ForEach(f => Attendants.Add(f));
            Attendants = Attendants.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(Attendants));

            Security.Clear();
            CongMembers.Where(f => f.Security).ToList().ForEach(f => Security.Add(f));
            Security = Security.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(Security));

            Sound.Clear();
            CongMembers.Where(f => f.SoundDesk).ToList().ForEach(f => {
                if (!Sound.Contains(f)) Sound.Add(f);
            });
            Sound = Sound.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(Sound));

            Platform.Clear();
            CongMembers.Where(f => f.Platform).ToList().ForEach(f => {
                if (!Platform.Contains(f)) Platform.Add(f);
            });
            Platform = Platform.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(Platform));

            RovingMic.Clear();
            CongMembers.Where(f => f.RovingMic).ToList().ForEach(f => {
                if (!RovingMic.Contains(f)) RovingMic.Add(f);
            });
            RovingMic = RovingMic.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(RovingMic));
        }

        protected override void AddModelObjectToDbContext()
        {
            if (IsValidSchedule())
            {
                Repository.Store(Selected);
            }
        }

        protected bool IsValidSchedule()
        {
            return Selected != null && Selected.WeekStarting > DateTime.MinValue;
        }

        private void SetWeekStartingDate(T schedule)
        {
            if (Index != null && Index.Count == 0)
            {
                schedule.WeekStarting = WeekNumberAdapter.GetFirstDateOfWeekIso8601(DateTime.Now);
            }
            else
            {
                var latestScheduleDate = Index
                    .OrderByDescending(s => s.WeekStarting)
                    .Select(s => s.WeekStarting)
                    .First();
                schedule.WeekStarting = latestScheduleDate.AddDays(7);
            }
        }

        #region Lookups

        public List<LocalCongregationMember> Attendants { get; private set; }

        public List<LocalCongregationMember> Security { get; private set; }

        public List<LocalCongregationMember> Sound { get; private set; }

        public List<LocalCongregationMember> Platform { get; private set; }

        public List<LocalCongregationMember> RovingMic { get; private set; }

        public List<LocalCongregationMember> Chairmen { get; protected set; }

        #endregion

        #region Events

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Selected) && IsItemSelected)
            {
                if (Selected == null)
                {
                    throw new ArgumentNullException(
                        "Expected Selected Item and Model Object to be in sync!");
                }
                if (Selected.WeekStarting == DateTime.MinValue)
                {
                    SetWeekStartingDate(Selected);
                }
            }
        }

        private void OnScheduleModelObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            LoadLookups();
            foreach (var friend in Selected.Participants)
            {
                friend?.SetIsPotentiallyOverloaded(Selected);
            }
        }

        private void OnCopyToClipboard()
        {
            // TODO format the output of model object
            var data = new DataPackage();
            data.SetText(Selected.ToString());
            Clipboard.SetContent(data);
        }
        public bool CanCopyToClipboard => Selected != null;

        #endregion
    }
}
