using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Ulutashus.Xamarin.XUtils.Portable
{
    public class ControllerBase : ObservableDictionary
    {
        public ControllerBase()
        {
        }

        public virtual void OnLoad()
        {
            // to override
        }

        public virtual void OnUnload()
        {
            // to override
        }
    }
}
