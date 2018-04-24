using System;
using System.Linq;
using OpenKHS.Models;
using OpenKHS.Facades;
using OpenKHS.Interfaces;

using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : IndexBoundViewModelBase<Friend>
    {
        public CongregationViewModel() : base(new DbFriendGatewayFacade())
        {
            Initialise(DataGatewayFacade.Index());
            
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

        public ICommand FormSaveCmd => new RelayCommand(OnFormSave);

        private void OnFormSave()
        {
            foreach (var friend in Index)
            {
                if (friend.Name != string.Empty)
                {
                    var validDateRanges = friend.UnavailablePeriods
                        .Where(u => u.Start != DateTime.MinValue)
                        .Where(u => u.End != DateTime.MinValue)
                        .ToList();
                    friend.UnavailablePeriods = validDateRanges;
                }
            }
            Save();
        }
    }
}
