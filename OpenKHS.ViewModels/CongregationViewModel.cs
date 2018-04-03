﻿using System;
using System.Linq;
using MvvmDialogs;
using OpenKHS.Facades;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : ModelBoundViewModelBase<Congregation>
    {
        private readonly IDataGateway _dataGateway;
        private readonly IDialogService _dialogService;
        private Congregation _congregation;
        private Friend _selectedCongMember;

        public CongregationViewModel(IDataGateway dataGateway, IDialogService dialogService)
        {
            _dataGateway = dataGateway;
            _dialogService = dialogService;
            _congregation = new DataGatewayFacade<Congregation>(_dataGateway).Show();
            if (_congregation.Members.Count > 0)
            {
                Members = new ObservableCollection<Friend>(_congregation.Members);
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
            _congregation.Members.Clear();
            foreach (var friend in Members)
            {
                if (friend.Name != string.Empty)
                {
                    var validDateRanges = friend.UnavailablePeriods
                        .Where(u => u.Start != DateTime.MinValue)
                        .Where(u => u.End != DateTime.MinValue)
                        .ToList();
                    friend.UnavailablePeriods = validDateRanges;

                    _congregation.Members.Add(friend);
                }
            }
            new DataGatewayFacade<Congregation>(_dataGateway).Update(_congregation);
        }
    }
}
