using B4.EE.MV.Models;
using B4.EE.MV.Models.Database;
using B4.EE.MV.Services;
using FreshMvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.MV.ViewModels
{
    public class FavoritesViewModel: FreshBasePageModel
    {
        private bool isRefreshing;
        private DatabaseService dbService;
        private ObservableCollection<Location> locationList;
        private Location selectedLocation;
        
        public override void Init(object initData)
        {
            dbService = new DatabaseService();
        }

        public ICommand AddFav => new Command(
            async () => await CoreMethods.PushPageModel<AddFavoriteViewModel>()
        );

        public ICommand Refresh => new Command(() => {
            IsRefreshing = true;
            LocationList = new ObservableCollection<Location>(dbService.GetLocations());
            IsRefreshing = false;
        });

        public ICommand RemoveFavorite => new Command<Location>(
            async (Location location) => {
                try
                {
                    dbService.RemoveLocation(location);
                    Refresh.Execute(null);
                }
                catch(Exception ex)
                {
                    await CoreMethods.DisplayAlert("Error", ex.Message, "Ok");
                }
            }
        );

        public ICommand ShowSettings => new Command(
            async () => await CoreMethods.PushPageModel<SettingsViewModel>()
        );

        public ObservableCollection<Location> LocationList
        {
            get { return locationList; }
            set { locationList = value; RaisePropertyChanged(nameof(LocationList)); }
        }

        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                selectedLocation = value;
                RaisePropertyChanged(nameof(SelectedLocation));
                dbService.SetSelectedLocation(SelectedLocation);
            }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; RaisePropertyChanged(nameof(IsRefreshing)); }
        }

        public override void ReverseInit(object returnedData)
        {
            WeatherApiResponse newFavorite = returnedData as WeatherApiResponse;
            dbService.AddLocation(newFavorite.Id, newFavorite.Name);
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            if(Settings.AutoRefresh)
                Refresh.Execute(null);
        }
    }
}
