using System;
using System.Linq;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : ModelBoundViewModelBase<Congregation>
    {
        private Friend _selectedCongMember;

        public CongregationViewModel(IDataGateway dataGateway)
            : base(dataGateway)
        {
            Initialise();

            if (ModelObject.Members.Count > 0)
            {
                Members = new ObservableCollection<Friend>(ModelObject.Members);
            } 
            else
            {
                Members = new ObservableCollection<Friend>
                {
                    new Friend()
                };
            }
        }

        public ObservableCollection<Friend> Members { get; }

        public Friend SelectedCongMember
        {
            get => _selectedCongMember;
            set
            {
                Set(ref _selectedCongMember, value);
                RaisePropertyChanged(nameof(CongMemberSelected));
            }
        }

        public bool CongMemberSelected
        {
            get => SelectedCongMember != null;
        }

        public ICommand FormSaveCmd => new RelayCommand(OnFormSave);

        private void OnFormSave()
        {
            ModelObject.Members.Clear();
            foreach (var friend in Members)
            {
                if (friend.Name != string.Empty)
                {
                    var validDateRanges = friend.UnavailablePeriods
                        .Where(u => u.Start != DateTime.MinValue)
                        .Where(u => u.End != DateTime.MinValue)
                        .ToList();
                    friend.UnavailablePeriods = validDateRanges;

                    ModelObject.Members.Add(friend);
                }
            }
            SaveForm();
        }
    }
}
