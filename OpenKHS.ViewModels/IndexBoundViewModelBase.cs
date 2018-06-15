using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenKHS.Interfaces;
using OpenKHS.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.ComponentModel;

namespace OpenKHS.ViewModels
{
    public abstract class IndexBoundViewModelBase<T> : ModelBoundViewModelBase<T>, IIndexBoundViewModel<T> 
        where T : IModel, new()
    {
        public IndexBoundViewModelBase(DatabaseContext dbContext) : base(dbContext)
        {
            Index = new ObservableCollection<T>();
            NewCmd = new RelayCommand(OnNew, () => GlobalViewState.IsNotBusy);
            DeleteSelectedItemCmd = new RelayCommand(OnDeleteSelectedItem, () => CanExecute);
        }

        protected virtual void Initialise(IList<T> data, T defaultFirstItem)
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
            SelectedItem = Index.FirstOrDefault();
        }

        public ObservableCollection<T> Index { get; set; }

        public ICommand NewCmd { get; }

        public ICommand DeleteSelectedItemCmd { get; }

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

        private void OnModelObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(IsItemSelected));
        }

        public virtual bool IsItemSelected => SelectedItem != null;

        public override bool CanExecute => GlobalViewState.IsNotBusy && IsItemSelected;

        private void OnNew()
        {
            New();
        }

        protected virtual void New()
        {
            var @new = new T();
            Index.Add(@new);
            SelectedItem = @new;
        }

        private void OnDeleteSelectedItem()
        {
            if (SelectedItem == null)
            {
                throw new ArgumentNullException("Expected to have the selected item set!");
            }
            Index.Remove(SelectedItem);
            Repository.Delete(SelectedItem);
        }
    }
}
