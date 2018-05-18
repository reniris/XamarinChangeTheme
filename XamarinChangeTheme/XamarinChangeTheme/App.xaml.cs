using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinChangeTheme.View.Themes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinChangeTheme
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new View.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private ResourceDictionary dict = null;

        public void ChangeTheme(ThemeType theme)
        {
            if (dict == null)
            {
                dict = Application.Current.Resources.MergedDictionaries.First();
            }

            // テーマをリソース・ディクショナリのソースに指定
            string themeUri = String.Format("View/Themes/{0}Theme.xaml", theme.ToString());
            dict.Source = new Uri(themeUri);
        }
    }
}
