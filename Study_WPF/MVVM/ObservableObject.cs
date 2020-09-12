using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared_Lib.MVVM
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public Guid GuId { get; set; }

        #region ContextMenuItems

        private ObservableCollection<BaseDataObject> _ContextMenuItems;

        public ObservableCollection<BaseDataObject> ContextMenuItems
        {
            get
            {
                if (_ContextMenuItems == null)
                {
                    _ContextMenuItems = new ObservableCollection<BaseDataObject>();
                }

                return _ContextMenuItems;
            }
            set { SetProperty(ref _ContextMenuItems, value); }
        }

        #endregion ContextMenuItems

        #region Items

        private ObservableCollection<BaseDataObject> _Items;

        public ObservableCollection<BaseDataObject> Items
        {
            get
            {
                if (_Items == null)
                {
                    _Items = new ObservableCollection<BaseDataObject>();
                }

                return _Items;
            }
            set { SetProperty(ref _Items, value); }
        }

        #endregion Items

        protected bool SetProperty<T>(
            ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            OnPropertyChanging(propertyName, backingStore, value);

            backingStore = value;
            onChanged?.Invoke();
            ModifiedDate = DateTime.Now;
            OnPropertyChanged(propertyName);
            return true;
        }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;

        public EventHandler<PropertyChangingEvent> PropertyChanging;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanging(string propertyName, object oldvalue, object newvalue)
        {
            var changing = PropertyChanging;
            if (changing == null)
            {
                return;
            }

            changing.Invoke(this, new PropertyChangingEvent(propertyName, oldvalue, newvalue));
        }

        public void Notify([CallerMemberName] string propertyName = "")
        {
            OnPropertyChanged(propertyName);
        }
    }

    public class PropertyChangingEvent : EventArgs
    {
        public PropertyChangingEvent(string propertyName, object oldValue, object newValue)
        {
            PropertyName = propertyName;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public string PropertyName { get; }
        public object OldValue { get; }
        public object NewValue { get; }
    }
}