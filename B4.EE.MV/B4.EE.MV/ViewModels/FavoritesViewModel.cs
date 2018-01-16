﻿using B4.EE.MV.Models;
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
        private DatabaseService dbService;
        private ObservableCollection<Location> locationList;
        
        public override void Init(object initData)
        {
            dbService = new DatabaseService();
        }

        public ICommand AddFav => new Command(
            async () => await CoreMethods.PushPageModel<AddFavoriteViewModel>()
        );

        public ICommand Refresh => new Command(
            () => LocationList = new ObservableCollection<Location>(dbService.GetLocations())
        );

        public ObservableCollection<Location> LocationList
        {
            get { return locationList; }
            set { locationList = value; RaisePropertyChanged(nameof(LocationList)); }
        }

        public override void ReverseInit(object returnedData)
        {
            WeatherApiResponse newFavorite = returnedData as WeatherApiResponse;
            dbService.AddLocation(newFavorite.Id, newFavorite.Name);
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            Refresh.Execute(null);
        }
    }
}