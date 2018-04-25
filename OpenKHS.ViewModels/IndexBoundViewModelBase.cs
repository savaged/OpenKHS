using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenKHS.Interfaces;
using OpenKHS.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace OpenKHS.ViewModels
{
    public abstract class IndexBoundViewModelBase<T> : ModelBoundViewModelBase<T>, IIndexBoundViewModel<T> 
        where T : IModel, new()
    {
        private ICommand _deleteSelectedItemCmd;

        public IndexBoundViewModelBase(DatabaseContext dbContext) : base(dbContext)
        {
            Index = new ObservableCollection<T>();
            _deleteSelectedItemCmd = new RelayCommand(OnDeleteSelectedItem, () => CanExecute);
        }

        protected void Initialise(IList<T> data, T defaultFirstItem)
        {
            if (Index.Count > 0)
            {
                Index.Clear();
            }
            foreach (var item in data)
            {
                Index.Add(item);
            }
            if (Index.Count == 0 && defaultFirstItem != null)
            {
                Index.Add(defaultFirstItem);
            }
            Initialise(data.FirstOrDefault());
        }

        public ObservableCollection<T> Index { get; set; }

        public ICommand DeleteSelectedItemCmd => _deleteSelectedItemCmd;

        public T SelectedItem
        {
            get => ModelObject;
            set
            {
                ModelObject = value;
                RaisePropertyChanged(nameof(SelectedItem));
                RaisePropertyChanged(nameof(IsItemSelected));
            }
        }

        public virtual bool IsItemSelected => SelectedItem != null;

        public override bool CanExecute => GlobalViewState.IsNotBusy && IsItemSelected;

        private void OnDeleteSelectedItem()
        {
            if (SelectedItem == null)
            {
                throw new ArgumentNullException("Expected to have the selected item set!");
            }
            Index.Remove(SelectedItem);
            DbContext.Delete(SelectedItem);
        }
    }
}
