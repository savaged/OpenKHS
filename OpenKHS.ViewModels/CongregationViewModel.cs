﻿using System;
using OpenKHS.Models;
using System.Collections.ObjectModel;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : IndexBoundViewModelBase<Friend>
    {
        public CongregationViewModel()
        {
            var list = DbContext.Index();
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

        protected override void AddModelObjectToDbContext() { if (ModelObject != null) DbContext.Store(ModelObject); }
    }
}
