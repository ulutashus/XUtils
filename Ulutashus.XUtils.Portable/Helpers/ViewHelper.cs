﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ulutashus.XUtils.Portable.Contracts;

namespace Ulutashus.XUtils.Portable.Helpers
{
    public class ViewHelper<T> where T : ControllerBase, new()
    {
        private readonly IView<T> _view;
        private readonly Dictionary<string, Action<object, object>> _observersDict;

        public ViewHelper(IView<T> view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            _view = view;
            _view.Controller = new T();
            _observersDict = new Dictionary<string, Action<object, object>>();
            _view.Controller.PropertyChanged += OnControllerPropertyChanged;
        }

        public void ObserveProperty<TController, TProperty>(
            Expression<Func<TController, TProperty>> property,
            PropertyChangedDeleage<TProperty> onChanged) where TController : ControllerBase
        {
            var propName = GetPropertyName(property);
            _observersDict[propName] = (oldValue, newValue) =>
            {
                onChanged((TProperty)oldValue, (TProperty)newValue);
            };
        }

        #region Private Helpers
        private void OnControllerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var args = e as PropertyChangedDetailedEventArgs;
            if (_observersDict.ContainsKey(e.PropertyName))
            {
                _observersDict[e.PropertyName].Invoke(args.OldValue, args.NewValue);
            }
        }

        private string GetPropertyName<TObject, TProperty>(Expression<Func<TObject, TProperty>> propertyExp)
        {
            var member = propertyExp.Body as MemberExpression;
            if (member != null)
            {
                return member.Member.Name;
            }
            throw new ArgumentException("Property does not exist.");
        }
        #endregion
    }
}