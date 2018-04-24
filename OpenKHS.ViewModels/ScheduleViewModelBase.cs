using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;
using OpenKHS.Models.Utils;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public abstract class ScheduleViewModelBase<T> : IndexBoundViewModelBase<T>
        where T : ISchedule, new()
    {
        private RelayCommand<DateTime> _viewWeekCmd;

        public ScheduleViewModelBase(DatabaseContext dbContext, IList<Friend> congMembers) 
            : base(dbContext)
        {
            var weekStarting = WeekNumberAdapter.GetFirstDateOfWeekIso8601(DateTime.Now);
            Initialise(DbContext.Index(), GetDefaultSchedule(weekStarting));

            _viewWeekCmd = new RelayCommand<DateTime>(OnViewWeek, (f) => CanExecute);
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
            var defaultSchedule = GetDefaultSchedule(weekStarting);
            SelectedItem = defaultSchedule;
        }
        protected abstract T GetDefaultSchedule(DateTime weekStarting);

        #endregion
    }
}
