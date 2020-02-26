using System;
using System.ComponentModel.DataAnnotations;
using GalaSoft.MvvmLight;

namespace OpenKHS.Models
{
    public class UnavailablePeriod : ObservableObject
    {
        private int _id;
        private DateTime _start;
        private DateTime _end;

        private int _assigneeId;

        public UnavailablePeriod()
        {
            AssigneeId = NullAssignee.Default.Id;
            _start = DateTime.Now;
            _end = DateTime.Now;
        }

        public int Id 
        {
            get => _id;
            set => Set(ref _id, value);
        }

        [Required]
        public int AssigneeId
        {
            get => _assigneeId;
            set => Set(ref _assigneeId, value);
        }

        public DateTime Start 
        { 
            get => _start;
            set => Set(ref _start, value);
        }

        public DateTime End
        { 
            get => _end;
            set => Set(ref _end, value);
        }
    }
}