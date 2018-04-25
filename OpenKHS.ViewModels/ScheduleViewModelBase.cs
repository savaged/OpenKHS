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

        protected abstract T GetDefaultSchedule(DateTime weekStarting);

        public override void Cleanup()
        {
            PropertyChanged -= OnPropertyChanged;
            base.Cleanup();
        }
        
        protected virtual void LoadLookups(IList<Friend> congMembers)
        {
            congMembers.Where(f => f.Attendant).ToList().ForEach(f => {
                if (!Attendants.Contains(f)) Attendants.Add(f);
            });
            congMembers.Where(f => f.Security).ToList().ForEach(f => {
                if (!Security.Contains(f)) Security.Add(f);
            });
            congMembers.Where(f => f.SoundDesk).ToList().ForEach(f => {
                if (!Sound.Contains(f)) Sound.Add(f);
            });
            congMembers.Where(f => f.Platform).ToList().ForEach(f => {
                if (!Platform.Contains(f)) Platform.Add(f);
            });
            congMembers.Where(f => f.RovingMic).ToList().ForEach(f => {
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

        private void OnViewWeek(DateTime dateTime)
        {
            var weekStarting = WeekNumberAdapter.GetFirstDateOfWeekIso8601(dateTime);
            var defaultSchedule = GetDefaultSchedule(weekStarting);
            SelectedItem = defaultSchedule;
        }


        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedItem) && IsItemSelected)
            {
                // TODO set-up new schedule?
            }
        }

        private void OnCongregationChanged(CongregationChangedMessage msg)
        {
            LoadLookups(msg?.Members);
        }

        #endregion
    }
}
