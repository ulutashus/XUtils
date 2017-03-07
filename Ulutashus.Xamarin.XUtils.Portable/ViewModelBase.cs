using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ulutashus.Xamarin.XUtils.Portable
{
    public class ViewModelBase : ObservableDictionary
    {
        public ViewModelBase()
        {
            Commands = new XamlSafeDictionary<string, ICommand>();
        }

        public XamlSafeDictionary<string, ICommand> Commands { get; private set; }
    }
}
