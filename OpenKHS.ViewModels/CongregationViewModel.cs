using System;
using System.Linq;
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
            list = DbContext.Friends.ToList();
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

        protected override void AddModelObjectToDbContext() { if (ModelObject != null) DbContext.Add(ModelObject); }
    }
}
