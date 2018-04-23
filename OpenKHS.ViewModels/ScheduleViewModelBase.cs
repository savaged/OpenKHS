using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;
using OpenKHS.Models.Utils;

namespace OpenKHS.ViewModels
{
    public abstract class ScheduleViewModelBase<T> : ModelBoundViewModelBase<T>
        where T : ISchedule, new()
    {
        private RelayCommand<DateTime> _viewWeekCmd;

        public ScheduleViewModelBase(IList<Friend> congMembers)
        {
            _viewWeekCmd = new RelayCommand<DateTime>(OnViewWeek, (f) => GlobalViewState.IsNotBusy);
            LoadLookups(congMembers);
        }

        protected virtual void LoadLookups(IList<Friend> congMembers)
        {
            Attendants = congMembers.Where(f => f.Attendant).ToList();
        }

        public RelayCommand<DateTime> ViewWeekCmd => _viewWeekCmd;

        #region Lookups

        public IList<Friend> Attendants { get; private set; }

        #endregion

        #region Events

        private void OnViewWeek(DateTime dateTime)
        {
            var weekStarting = WeekNumberAdapter.GetFirstDateOfWeekIso8601(dateTime);
            LoadSchedule(weekStarting);
        }
        protected abstract void LoadSchedule(DateTime weekStarting);

        #endregion
    }
}
