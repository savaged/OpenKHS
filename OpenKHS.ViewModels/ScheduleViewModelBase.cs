using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Interfaces;
using OpenKHS.Models.Utils;
using OpenKHS.Data;
using System.Collections.ObjectModel;

namespace OpenKHS.ViewModels
{
    public abstract class ScheduleViewModelBase<T> : IndexBoundViewModelBase<T>
        where T : ISchedule, new()
    {
        public ScheduleViewModelBase(DatabaseContext dbContext, IList<Friend> congMembers) 
            : base(dbContext)
        {
            CongMembers = congMembers;
            Attendants = new List<Friend>();
            Security = new List<Friend>();
            Sound = new List<Friend>();
            Platform = new List<Friend>();
            RovingMic = new List<Friend>();

            var weekStarting = WeekNumberAdapter.GetFirstDateOfWeekIso8601(DateTime.Now);
            Initialise(DbContext.Index(), GetDefaultSchedule(weekStarting));

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

        protected IList<Friend> CongMembers { get; private set; }

        protected T GetDefaultSchedule(DateTime weekStarting)
        {
            var defaultSchedule = DbContext.Index().SingleOrDefault(s => s.WeekStarting == weekStarting);
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
            SelectedItem = @new;
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
                DbContext.Store(ModelObject);
            }
        }

        protected bool IsValidSchedule()
        {
            return ModelObject != null && ModelObject.WeekStarting > DateTime.MinValue;
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

        public List<Friend> Attendants { get; private set; }

        public List<Friend> Security { get; private set; }

        public List<Friend> Sound { get; private set; }

        public List<Friend> Platform { get; private set; }

        public List<Friend> RovingMic { get; private set; }

        #endregion

        #region Events

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedItem) && IsItemSelected)
            {
                if (ModelObject == null)
                {
                    throw new ArgumentNullException("Expected Selected Item and Model Object to be in sync!");
                }
                if (ModelObject.WeekStarting == DateTime.MinValue)
                {
                    SetWeekStartingDate(ModelObject);
                }
            }
        }

        private void OnScheduleModelObjectPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            LoadLookups();
        }

        #endregion
    }
}
