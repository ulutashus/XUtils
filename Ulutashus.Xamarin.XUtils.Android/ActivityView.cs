using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Ulutashus.Xamarin.XUtils.Portable;
using Ulutashus.Xamarin.XUtils.Portable.Contracts;
using Ulutashus.Xamarin.XUtils.Portable.Helpers;

namespace Ulutashus.Xamarin.XUtils.Android
{
    public class ActivityView<T> : Activity, IView<T> where T : ControllerBase, new()
    {
        private readonly ViewHelper<T> _viewHelper;

        public ActivityView()
        {
            _viewHelper = new ViewHelper<T>(this);
        }

        public void ObserveProperty<TProperty>(Expression<Func<T, TProperty>> property,
           PropertyChangedDeleage<TProperty> onChanged)
        {
            _viewHelper.ObserveProperty(property, onChanged);
        }

        #region Properties
        public T Controller { get; set; }
        #endregion
    }
}
