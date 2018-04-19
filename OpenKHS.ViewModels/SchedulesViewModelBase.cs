using System;
using System.Collections.ObjectModel;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public abstract class SchedulesViewModelBase<TModel, TIndex>
        : ModelBoundViewModelBase<TModel>
        where TModel : Weeks<TIndex>, new()
        where TIndex : ISchedule, new()
    {
        private TIndex _selectedItem;

        public SchedulesViewModelBase()
        {
            Index = new ObservableCollection<TIndex>();
        }

        protected override void Initialise()
        {
            base.Initialise();
            if (Index.Count > 0)
            {
                Index.Clear();
            }
            if (ModelObject.Schedules != null)
            {
                foreach (var schedule in ModelObject.Schedules)
                {
                    Index.Add(schedule);
                }
            }
        }

        public ObservableCollection<TIndex> Index { get; set; }

        public TIndex SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                RaisePropertyChanged(nameof(IsItemSelected));
            }
        }

        public bool IsItemSelected => SelectedItem != null;

        public override void Save()
        {
            ModelObject.Schedules.Clear();
            foreach (var item in Index)
            {
                ModelObject.Schedules.Add(item);
            }
            base.Save();
        }
    }
}
