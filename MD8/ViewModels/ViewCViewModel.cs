using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MD8.ViewModels
{
    public class ViewCViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        private string _title = "View C";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        void ExecuteNavigateCommand()  // Equivale al Navigate() del vídeo de Brian Lagunas
        {

            //_navigationService.GoBackToRootAsync();
            _navigationService.NavigateAsync("/PrismMasterDetailPage/NavigationPage/ViewA");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Console.WriteLine("DEBUG - OnNavigatedFrom() in ViewC");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Console.WriteLine("DEBUG - OnNavigatedTo() in ViewC");
            Console.WriteLine("DEBUG - Estamos en {0}", _navigationService.GetNavigationUriPath());

            if (parameters.ContainsKey("id"))
                Title = (string)parameters["id"];
        }

        public ViewCViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
