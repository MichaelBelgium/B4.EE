using B4.EE.MV.Models;
using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.MV.ViewModels
{
    public class FavoritesViewModel: FreshBasePageModel
    {
        public ICommand AddFav => new Command(
            async () => await CoreMethods.PushPageModel<AddFavoriteViewModel>()
        );

        public override void ReverseInit(object returnedData)
        {
            WeatherApiResponse newFavorite = returnedData as WeatherApiResponse;
            //todo process more
        }
    }
}
