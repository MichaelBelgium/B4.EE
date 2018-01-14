using B4.EE.MV.Services;
using FreshMvvm;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.MV.ViewModels
{
    public class TestViewModel: FreshBasePageModel, INotifyPropertyChanged
    {
        private ApiService service;

        public TestViewModel()
        {
            service = new ApiService();
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; RaisePropertyChanged(nameof(City)); }
        }


        public ICommand GetRequest => new Command(
            async () => await service.GetCityWeather("Brugge")
        );

        public ICommand GetRequestGps => new Command(
            async () => await service.GetCityWeatherGps()
        );

        public ICommand GetRequestForecast => new Command(
            async () => await service.GetForecast("Brugge")
        );

        public ICommand GetRequestForecastGps => new Command(
            async () => await service.GetForecastGps()    
        );
    }
}
