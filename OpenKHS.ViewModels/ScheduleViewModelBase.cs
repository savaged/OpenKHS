using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Interfaces;
using OpenKHS.Models.Utils;
using OpenKHS.Data;
using OpenKHS.ViewModels.Messages;

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
            LoadLookups(congMembers);

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
            // TODO change lookups to be ObservableCollection objects so they update on refresh
            Attendants = congMembers.Where(f => f.Attendant).ToList();
            Security = congMembers.Where(f => f.Security).ToList();
            Sound = congMembers.Where(f => f.SoundDesk).ToList();
            Platform = congMembers.Where(f => f.Platform).ToList();
            RovingMic = congMembers.Where(f => f.RovingMic).ToList();
        }

        protected bool IsValidSchedule()
        {
            return ModelObject != null && ModelObject.WeekStarting > DateTime.MinValue;
        }

        #region Lookups

        public IList<Friend> Attendants { get; private set; }

        public IList<Friend> Security { get; private set; }

        public IList<Friend> Sound { get; private set; }

        public IList<Friend> Platform { get; private set; }

        public IList<Friend> RovingMic { get; private set; }

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
            // TODO change lookups to be ObservableCollection objects so they update on refresh
        }

        #endregion
    }
}
