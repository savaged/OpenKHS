using OpenKHS.Models;
using OpenKHS.Data;
using OpenKHS.ViewModels.Messages;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System;
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
            Index.CollectionChanged += IndexChanged;
            _togglePrivilegesCmd = new RelayCommand(OnTogglePrivileges, () => CanExecute);
            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ModelObject))
            {
                _previousTogglePrivilegesSetting = false;
            }
        }

        public override void Cleanup()
        {
            Index.CollectionChanged -= IndexChanged;
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

        private void IndexChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var isChangeRelevant = false;
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                if (e.NewItems != null && e.NewItems.Count > 0)
                {
                    foreach (Friend newItem in e.NewItems)
                    {
                        if (!string.IsNullOrEmpty(newItem.Name))
                        {
                            isChangeRelevant = true;
                            break;
                        }
                    }
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                isChangeRelevant = true;
            }
            if (isChangeRelevant)
            {
                var members = new List<Friend>();
                foreach (var member in Index)
                {
                    members.Add(member);
                }
                MessengerInstance.Send(new CongregationChangedMessage(members));
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
    }
}
