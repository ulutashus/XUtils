using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulutashus.Xamarin.XUtils.Portable
{
    public class XamlSafeList<T> : List<T>
    {
        public XamlSafeList()
        {

        }

        public XamlSafeList(IList<T> list)
        {
            if (list != null)
            {
                AddRange(list);
            }
        }

        public new T this[int index]
        {
            get
            {
                return (index >= Count) ? default(T) : base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}
