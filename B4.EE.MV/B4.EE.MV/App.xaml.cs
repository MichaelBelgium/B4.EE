using B4.EE.MV.ViewModels;
using FreshMvvm;

using Xamarin.Forms;

namespace B4.EE.MV
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var tabbedPage = new FreshTabbedNavigationContainer();
            tabbedPage.AddTab<FavoritesViewModel>("Favorites", "star_o.png");
            tabbedPage.AddTab<WeatherViewModel>("Weather", "crosshair.png");
            tabbedPage.AddTab<ForecastViewModel>("Forecast", "cloud.png");
            //tabbedPage.AddTab<TestViewModel>("Test", null);
            MainPage = tabbedPage;
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
