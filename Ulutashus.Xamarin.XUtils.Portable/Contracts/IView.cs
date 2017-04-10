using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ulutashus.Xamarin.XUtils.Portable.Contracts
{
    public interface IView<T> where T : ControllerBase
    {
        T Controller { get; set; }

        void InitializeBindings();

        void BindProperty<TProperty>(Expression<Func<T, TProperty>> property,
            PropertyChangedDeleage<TProperty> onChanged);
    }

    public delegate void PropertyChangedDeleage<TProperty>(TProperty oldValue, TProperty newValue);
}
