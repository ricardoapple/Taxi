using Taxi.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using Taxi.Common.Helpers;

namespace Taxi.Prism.ViewModels
{
    public class MenuItemViewModel : Menu
    {
        //Los ViewModel son clases que tienen la logica de navegación cuando estan metidas eb una lista
        //Es el origen de la lista 
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenuAsync));

        private async void SelectMenuAsync()
        {
            if (PageName == "LoginPage" && Settings.IsLogin)
            {
                Settings.IsLogin = false;
                Settings.User = null;
                Settings.Token = null;
            }

            await _navigationService.NavigateAsync($"/TaxiMasterDetailPage/NavigationPage/{PageName}");
        }
    }
}
