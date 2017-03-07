using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulutashus.XUtils.Portable
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name, object oldValue, object newValue)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedDetailedEventArgs(name, oldValue, newValue));
        }
    }

    public class PropertyChangedDetailedEventArgs : PropertyChangedEventArgs
    {
        public PropertyChangedDetailedEventArgs(string propertyName, object oldValue, object newValue)
            : base(propertyName)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public object OldValue { get; set; }

        public object NewValue { get; set; }
    }
}
