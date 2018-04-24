using System;
using System.Linq;
using OpenKHS.Data;
using OpenKHS.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : IndexBoundViewModelBase<Friend>
    {
        public CongregationViewModel() 
        {
            var list = new List<Friend>();
            using (var db = new DatabaseContext())
            {
                list = db.Friends.ToList();
            }
            Initialise(list);

            if (Index == null || Index.Count == 0)
            {
                Index = new ObservableCollection<Friend>
                {
                    new Friend()
                };
            }
        }

        public override bool IsItemSelected
        {
            get => base.IsItemSelected && !string.IsNullOrEmpty(SelectedItem.Name);        
        }
    }
}
