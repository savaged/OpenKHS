using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using OpenKHS.Data;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PublicTalksViewModel : LocalViewModelBase, IViewModel
    {
        private readonly PublicTalkOutlineRepository _outlinesRepo;
        private PublicTalkOutline _selectedItem;

        public PublicTalksViewModel()
        {
            _outlinesRepo = new PublicTalkOutlineRepository();
            Index = new ObservableCollection<PublicTalkOutline>(_outlinesRepo.Index());

            NewPublicTalkOutlineCmd = new RelayCommand(OnNewPublicTalkOutline, () => GlobalViewState.IsNotBusy);
            DeleteSelectedItemCmd = new RelayCommand(OnDeleteSelectedItem, () => CanExecute);
        }

        public ObservableCollection<PublicTalkOutline> Index { get; set; }

        public PublicTalkOutline SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                RaisePropertyChanged(nameof(IsItemSelected));
            }
        }

        public ICommand NewPublicTalkOutlineCmd { get; }

        public ICommand DeleteSelectedItemCmd { get; }

        public override bool CanExecute => GlobalViewState.IsNotBusy && IsItemSelected;

        public virtual bool IsItemSelected => SelectedItem != null;

        private void OnNewPublicTalkOutline()
        {
            var @new = new PublicTalkOutline();
            Index.Add(@new);
            SelectedItem = @new;
        }

        private void OnDeleteSelectedItem()
        {
            if (IsItemSelected)
            {
                _outlinesRepo.Delete(SelectedItem);
            }
        }

        public void Save()
        {
            if (IsItemSelected)
            {
                
                _outlinesRepo.Store(SelectedItem);
            }
        }
    }
}
