using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

using OpenKHS.Data;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public abstract class IndexBoundViewModelBase<T> : ModelBoundViewModelBase<T>, IIndexBoundViewModel<T> 
        where T : IModel, new()
    {
        public IndexBoundViewModelBase() 
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
            Selected = Index.FirstOrDefault();
        }

        public ObservableCollection<T> Index { get; set; }

        public ICommand NewCmd { get; }

        public ICommand DeleteSelectedItemCmd { get; }

        public override T Selected
        {
            get => base.Selected;
            set
            {
                base.Selected = value;
                RaisePropertyChanged(nameof(IsItemSelected));
            }
        }

        protected override void OnModelObjectPropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            base.OnModelObjectPropertyChanged(sender, e);

            RaisePropertyChanged(nameof(IsItemSelected));
        }

        public virtual bool IsItemSelected => Selected != null;

        public override bool CanExecute => GlobalViewState.IsNotBusy && IsItemSelected;

        private void OnNew()
        {
            New();
        }

        protected virtual void New()
        {
            var @new = new T();
            Index.Add(@new);
            Selected = @new;
        }

        private void OnDeleteSelectedItem()
        {
            if (Selected == null)
            {
                throw new ArgumentNullException("Expected to have the selected item set!");
            }
            Index.Remove(Selected);
            Repository.Delete(Selected);
        }
    }
}
