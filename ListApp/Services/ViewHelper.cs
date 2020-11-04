using ListApp.ViewModels;
using System;
using System.Collections.Generic;

namespace ListApp.Services
{
    public static class ViewHelper
    {
        private static Dictionary<Type, string> viewModelToViewKeyMap = new Dictionary<Type, string>();
        public static void RegisterView<T>(string viewKey) where T : SwitchableViewModel
        {
            viewModelToViewKeyMap.Add(typeof(T), viewKey);
        }

        public static string GetViewKey(Type t) 
        {
            return viewModelToViewKeyMap.GetValueOrDefault(t);
        }
    }
}
