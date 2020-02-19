using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CsvHelper;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Data;
using OpenKHS.Models;
using Savaged.BusyStateManager;
using TextCopy;

namespace OpenKHS.ViewModels
{
    public class IndexViewModel<T> : ModelBoundViewModel
        where T : class, IModel
    {
        public IndexViewModel(
            IBusyStateRegistry busyStateManager,
            IModelService modelService) 
            : base(busyStateManager, modelService)
        {
            Index = new ObservableCollection<T>();
            CopyToClipboardCmd = new RelayCommand(OnCopyToClipboard, () => CanCopyToClipboard);
        }

        public ObservableCollection<T> Index { get; }

        public ICommand CopyToClipboardCmd { get; }

        public bool CanCopyToClipboard => CanExecute && Index?.Count > 0;

        public virtual async Task LoadAsync()
        {
            Index.Clear();
            IList<T> index = new List<T>();
            await Task.Run(() => index = ModelService.GetIndex<T>());
            foreach (var model in index)
            {
                Index.Add(model);
            }
        }

        private string IndexToCsv()
        {
            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(Index);
                }
                bytes = ms.ToArray();
            }
            var value = Encoding.UTF8.GetString(bytes);
            return value;
        }

        private void OnCopyToClipboard()
        {
            var csv = IndexToCsv();
            Clipboard.SetText(csv);
        }

    }
}