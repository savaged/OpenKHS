using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels.Utils
{
    public class UserInputLookup<T> : List<T>, INotifyPropertyChanged
        where T : IModel, new()
    {
        private T _selectedItem;

        public UserInputLookup() { }

        public UserInputLookup(T selectedItem)
        {
            Add(selectedItem);
            _selectedItem = selectedItem;
        }

        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsItemSelected));
            }
        }

        public bool IsItemSelected => SelectedItem != null;

        public string NewItem
        {
            get => SelectedItem?.Name;
            set
            {
                var @new = new T { Name = value };
                Add(@new);
                SelectedItem = @new;
                RaisePropertyChanged();
            }
        }

        public new void Add(T value)
        {
            if (value != null && !string.IsNullOrEmpty(value.Name) && !string.IsNullOrWhiteSpace(value.Name))
            {
                if (!Contains(value))
                {
                    var matched = Find(o => o.Name == value.Name);
                    if (matched == null)
                    {
                        base.Add(value);
                    }
                }
            }
        }

        #region Property Changed Event
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
