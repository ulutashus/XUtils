using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Ulutashus.Xamarin.XUtils.Portable
{
    public class ObservableDictionary : ObservableDictionary<object>
    {

    }

    public class ObservableDictionary<T> : NotifyPropertyChanged where T : class
    {
        private Dictionary<string, T> _dictionary = new Dictionary<string, T>();

        protected T2 Get<T2>([CallerMemberName] string propertyName = null) where T2 : T
        {
            var value = propertyName != null ? this[propertyName] : null;
            return (value is T2) ? (T2)(object)value : default(T2);
        }

        protected void Set<T2>(T2 value, [CallerMemberName] string propertyName = null) where T2 : T
        {
            if (propertyName != null)
            {
                this[propertyName] = value;
            }
        }

        public void NotifyAll()
        {
            foreach(var pair in _dictionary)
            {
                InvokeMapChanged(pair.Key, pair.Value, pair.Value);
            }
        }

        #region Private Helpers
        private void InvokeMapChanged(string key, object oldValue, object newValue)
        {
            OnPropertyChanged(key, oldValue, newValue);
        }

        private T this[object keyObj]
        {
            get
            {
                if (keyObj != null)
                {
                    string key = keyObj.ToString();
                    if (_dictionary.ContainsKey(key))
                        return this._dictionary[key];
                }
                return null;
            }
            set
            {
                if (keyObj != null)
                {
                    string key = keyObj.ToString();
                    if (this._dictionary.ContainsKey(key))
                    {
                        var old = this._dictionary[key];
                        this._dictionary[key] = value;
                        this.InvokeMapChanged(key, old, value);
                    }
                    else
                    {
                        Add(key, value);
                    }
                }
            }
        }

        private void Add(string key, T value)
        {
            this._dictionary.Add(key, value);
            this.InvokeMapChanged(key, null, value);
        }
        #endregion
    }
}
