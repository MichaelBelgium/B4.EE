using B4.EE.MV.Models.Database;
using FreshMvvm;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.MV.ViewModels
{
    class SettingsViewModel: FreshBasePageModel
    {
        public List<string> UnitItems
        {
            get { return new List<string> { Settings.UNIT_IMPERIAL, Settings.UNIT_METRIC, Settings.UNIT_STANDARD }; }
        }
        private string selectedUnit;

        public ICommand SaveSettings => new Command(async () => {
            Settings.Unit = SelectedUnit;
            await CoreMethods.DisplayAlert("Success", "Settings were saved.", "Ok");
            await CoreMethods.PopToRoot(false);
        });

        public string SelectedUnit
        {
            get { return selectedUnit; }
            set { selectedUnit = value; }
        }
    }
}
