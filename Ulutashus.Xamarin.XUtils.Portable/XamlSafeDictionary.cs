using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulutashus.Xamarin.XUtils.Portable
{
    public class XamlSafeDictionary<K, V> : XamlSafeList<V>
    {
        private IDictionary<string, V> _dictionary;

        public XamlSafeDictionary()
        {
            _dictionary = new Dictionary<string, V>();
        }

        public XamlSafeDictionary(IDictionary<K, V> dictionary)
            : base(ToList(dictionary))
        {
            if (dictionary != null)
            {
                _dictionary = dictionary.ToDictionary(p => p.Key.ToString(), p => p.Value);
            }
        }

        public V this[string key]
        {
            get
            {
                return _dictionary.ContainsKey(key) ?
                    _dictionary[key] : default(V);
            }
            set
            {
                _dictionary[key] = value;
            }
        }

        private static IList<V> ToList(IDictionary<K, V> dictionary)
        {
            return dictionary == null ? null :
                dictionary.Select(p => p.Value).ToList();
        }

        public static implicit operator XamlSafeDictionary<K, V>(Dictionary<K, V> dictionary)
        {
            return new XamlSafeDictionary<K,V>(dictionary);
        }
    }
}
