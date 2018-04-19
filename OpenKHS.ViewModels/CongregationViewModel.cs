using System;
using System.Linq;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : IndexBoundViewModelBase<Friend>
    {
        public CongregationViewModel()
        {
            Initialise();

            if (Index.Count == 0)
            {
                Index = new ObservableCollection<Friend>
                {
                    new Friend()
                };
            }
        }

        public bool IsCongMemberSelected
        {
            get => SelectedItem != null && SelectedItem.Name != null && SelectedItem.Name != "";
        }

        public ICommand FormSaveCmd => new RelayCommand(OnFormSave);

        private void OnFormSave()
        {
            Index.Clear();
            foreach (var friend in Index)
            {
                if (friend.Name != string.Empty)
                {
                    var validDateRanges = friend.UnavailablePeriods
                        .Where(u => u.Start != DateTime.MinValue)
                        .Where(u => u.End != DateTime.MinValue)
                        .ToList();
                    friend.UnavailablePeriods = validDateRanges;

                    Index.Add(friend);
                }
            }
            Save();
        }
    }
}
