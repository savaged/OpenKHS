using System;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

using OpenKHS.Interfaces;
using OpenKHS.Models;
using OpenKHS.Models.Attributes;

namespace OpenKHS.ViewModels
{
    public class CongViewModel : IndexBoundViewModelBase<LocalCongregationMember>
    {
        private bool _previousTogglePrivilegesSetting;

        public CongViewModel()
            : base()
        {
            Initialise(Repository.Index(), null);
            TogglePrivilegesCmd = new RelayCommand(OnTogglePrivileges, () => CanExecute);
            PropertyChanged += OnPropertyChanged;
        }        

        public override void Cleanup()
        {
            PropertyChanged -= OnPropertyChanged;
            base.Cleanup();
        }

        public override bool IsItemSelected
        {
            get => base.IsItemSelected && !string.IsNullOrEmpty(Selected.Name);
        }

        protected override void AddModelObjectToDbContext()
        {
            if (Selected != null && !string.IsNullOrEmpty(Selected.Name))
            {
                Repository.Store(Selected);
            }
        }

        public ICommand TogglePrivilegesCmd { get; }

        private void OnTogglePrivileges()
        {
            if (Selected == null)
            {
                throw new ArgumentNullException("Always expected the Model to be set here.");
            }
            _previousTogglePrivilegesSetting = !_previousTogglePrivilegesSetting;

            foreach (var p in Selected.GetType().GetProperties())
            {
                if (Attribute.IsDefined(p, typeof(PrivilegeAttribute)))
                {
                    if (p.Name != nameof(Selected.ClmmMainHallOnly) &&
                        p.Name != nameof(Selected.ClmmSecondSchoolOnly) &&
                        p.Name != nameof(Selected.MainWtConductor))
                    {
                        p.SetValue(Selected, _previousTogglePrivilegesSetting);
                    }
                }
            }
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ModelBoundViewModelBase<LocalCongregationMember>.Selected))
            {
                _previousTogglePrivilegesSetting = false;
            }
        }

        protected override void OnModelObjectPropertyChanged(
            object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnModelObjectPropertyChanged(sender, e);

            if (!string.IsNullOrEmpty(Selected.Name))
            {
                RaisePropertyChanged(nameof(IsItemSelected));
            }
        }
    }
}
