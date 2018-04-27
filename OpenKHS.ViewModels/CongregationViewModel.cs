using System;
using OpenKHS.Models;
using OpenKHS.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using OpenKHS.Models.Attributes;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : IndexBoundViewModelBase<Friend>
    {
        private ICommand _togglePrivilegesCmd;
        private bool _previousTogglePrivilegesSetting;

        public CongregationViewModel(DatabaseContext dbContext) : base(dbContext)
        {
            Initialise(DbContext.Index(), null);
            _togglePrivilegesCmd = new RelayCommand(OnTogglePrivileges, () => CanExecute);
            PropertyChanged += OnPropertyChanged;
        }

        public override void Cleanup()
        {
            PropertyChanged -= OnPropertyChanged;
            base.Cleanup();
        }

        public override bool IsItemSelected
        {
            get => base.IsItemSelected && !string.IsNullOrEmpty(SelectedItem.Name);
        }

        protected override void AddModelObjectToDbContext()
        {
            if (ModelObject != null && !string.IsNullOrEmpty(ModelObject.Name))
            {
                DbContext.Store(ModelObject);
            }
        }

        public ICommand TogglePrivilegesCmd => _togglePrivilegesCmd;

        private void OnTogglePrivileges()
        {
            if (ModelObject == null)
            {
                throw new ArgumentNullException("Always expected the Model to be set here.");
            }
            _previousTogglePrivilegesSetting = !_previousTogglePrivilegesSetting;

            foreach (var p in ModelObject.GetType().GetProperties())
            {
                if (Attribute.IsDefined(p, typeof(PrivilegeAttribute)))
                {
                    if (p.Name != nameof(ModelObject.ClmmMainHallOnly) &&
                        p.Name != nameof(ModelObject.ClmmSecondSchoolOnly) &&
                        p.Name != nameof(ModelObject.MainWtConductor))
                    {
                        p.SetValue(ModelObject, _previousTogglePrivilegesSetting);
                    }
                }
            }
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ModelObject))
            {
                _previousTogglePrivilegesSetting = false;
            }
        }
    }
}
