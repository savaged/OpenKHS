using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Interfaces;
using OpenKHS.Models.Utils;
using OpenKHS.Data;
using OpenKHS.ViewModels.Messages;
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

            var weekStarting = WeekNumberAdapter.GetFirstDateOfWeekIso8601(DateTime.Now);
            Initialise(DbContext.Index(), GetDefaultSchedule(weekStarting));

            Attendants = new ObservableCollection<Friend>();
            Security = new ObservableCollection<Friend>();
            Sound = new ObservableCollection<Friend>();
            Platform = new ObservableCollection<Friend>();
            RovingMic = new ObservableCollection<Friend>();

            MessengerInstance.Register<CongregationChangedMessage>(this, OnCongregationChanged);
            PropertyChanged += OnPropertyChanged;
        }

        public override void Cleanup()
        {
            PropertyChanged -= OnPropertyChanged;
            base.Cleanup();
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
            CongMembers.Where(f => f.Attendant).ToList().ForEach(f => {
                if (!Attendants.Contains(f)) Attendants.Add(f);
            });
            CongMembers.Where(f => f.Security).ToList().ForEach(f => {
                if (!Security.Contains(f)) Security.Add(f);
            });
            CongMembers.Where(f => f.SoundDesk).ToList().ForEach(f => {
                if (!Sound.Contains(f)) Sound.Add(f);
            });
            CongMembers.Where(f => f.Platform).ToList().ForEach(f => {
                if (!Platform.Contains(f)) Platform.Add(f);
            });
            CongMembers.Where(f => f.RovingMic).ToList().ForEach(f => {
                if (!RovingMic.Contains(f)) RovingMic.Add(f);
            });
        }

        protected bool IsValidSchedule()
        {
            return ModelObject != null && ModelObject.WeekStarting > DateTime.MinValue;
        }

        #region Lookups

        public ObservableCollection<Friend> Attendants { get; private set; }

        public ObservableCollection<Friend> Security { get; private set; }

        public ObservableCollection<Friend> Sound { get; private set; }

        public ObservableCollection<Friend> Platform { get; private set; }

        public ObservableCollection<Friend> RovingMic { get; private set; }

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
                LoadLookups();
            }
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

        private void OnCongregationChanged(CongregationChangedMessage msg)
        {
            CongMembers = msg?.Members;
            LoadLookups();
        }

        #endregion
    }
}
