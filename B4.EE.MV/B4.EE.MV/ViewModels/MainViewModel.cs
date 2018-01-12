using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Input;
using B4.EE.MV.Services;
using FreshMvvm;
using Xamarin.Forms;

namespace B4.EE.MV.ViewModels
{
    class MainViewModel: FreshBasePageModel
    {
        private ApiService service;

        public MainViewModel()
        {
            service = new ApiService();
        }

        public ICommand GetRequest => new Command(
            () => service.GetCityWeather("Brugge")
        );
    }
}
