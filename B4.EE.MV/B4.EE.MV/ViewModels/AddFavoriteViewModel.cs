using B4.EE.MV.Services;
using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.MV.ViewModels
{
    class AddFavoriteViewModel: FreshBasePageModel
    {
        private string errorMessage, city;
        private ApiService service;

        public override void Init(object initData)
        {
            base.Init(initData);
            service = new ApiService();
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; RaisePropertyChanged(nameof(ErrorMessage)); }
        }

        public string City
        {
            get { return city; }
            set { city = value; RaisePropertyChanged(nameof(City)); }
        }

        public ICommand AddCity => new Command(async () => {
            if (string.IsNullOrEmpty(City))
            {
                ErrorMessage = "Enter a city";
                return;
            }

            var tmp = await service.GetCityWeather(City);
            if (tmp == null)
                ErrorMessage = "City not found";
            else
                await CoreMethods.PopPageModel(tmp);
        });

        public ICommand AddGps => new Command(async () => {
            var tmp = await service.GetCityWeatherGps();
            if (tmp == null)
                ErrorMessage = "An error has occured. Try later again.";
            else
                await CoreMethods.PopPageModel(tmp);
        });
    }
}
