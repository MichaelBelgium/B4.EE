using B4.EE.MV.Models;
using B4.EE.MV.Models.Database;
using B4.EE.MV.Services;
using FreshMvvm;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.MV.ViewModels
{
    class ForecastViewModel: FreshBasePageModel
    {
        private ApiService service;
        private ForecastApiResponse currentResponse;

        public override void Init(object initData)
        {
            service = new ApiService();
        }

        public ICommand Refresh => new Command(
            async () => CurrentResponse = await service.GetForecast(Settings.SelectedLocation.Name)
        );

        public ForecastApiResponse CurrentResponse
        {
            get { return currentResponse; }
            set { currentResponse = value; RaisePropertyChanged(nameof(CurrentResponse)); }
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            Refresh.Execute(null);
        }
    }
}
