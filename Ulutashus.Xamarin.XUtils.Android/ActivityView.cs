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
        private bool _isFirstStart = true;

        public ActivityView()
        {
            _viewHelper = new ViewHelper<T>(this);
            _viewHelper.Init();

        }

        public virtual void InitializeBindings()
        {
            // To Override
        }

        public void BindProperty<TProperty>(Expression<Func<T, TProperty>> property, 
            PropertyChangedDeleage<TProperty> onChanged)
        {
            _viewHelper.BindProperty(property, onChanged);
        }

        protected override void OnStart()
        {
            base.OnStart();
            if(_isFirstStart)
            {
                _isFirstStart = false;
                Controller.NotifyAll();
            }
            Controller.OnLoad();
        }

        protected override void OnStop()
        {
            base.OnStop();
            Controller.OnUnload();
        }

        #region Properties
        public T Controller { get; set; }
        #endregion
    }
}
