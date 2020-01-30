using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public abstract class IndexViewModel<T> : ModelBoundViewModel
        where T : IModel
    {
        public IndexViewModel(
            IDbContextFactory dbContextFactory) 
            : base(dbContextFactory)
        {
            Index = new ObservableCollection<T>();
            AddCmd = new RelayCommand(OnAdd, () => CanAdd);
        }

        public ObservableCollection<T> Index { get; }

        public abstract void Load();

        public ICommand AddCmd { get; set; }

        public bool CanAdd => CanExecute;

        protected virtual void OnAdd()
        {

        }
    }
}