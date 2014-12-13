using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace DynamicMultilingual.Utilities
{
    public class ResourceHelper
    {
        private static List<System.Windows.ResourceDictionary> _Resourcelist = new List<ResourceDictionary>();

        public static void LoadResource(string languageName)
        {
            var currentResourceDictionary = (from d in _Resourcelist
                                             where d.ToString().Equals(languageName)
                                             select d).FirstOrDefault();

            if (currentResourceDictionary == null)
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string langType = appPath + string.Format(@"/Langs/Language.{0}.xaml", languageName); // Language.zh-CN.xaml
                // App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(langType, UriKind.RelativeOrAbsolute) });
                var resourceDic = new ResourceDictionary() { Source = new Uri(langType, UriKind.RelativeOrAbsolute) };
                Application.Current.Resources.MergedDictionaries.Remove(resourceDic);
                Application.Current.Resources.MergedDictionaries.Add(resourceDic);
                CultureInfo cultureInfo = new CultureInfo(languageName);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
        }
    }
}
