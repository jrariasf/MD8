using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MD8.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        private string _title = "View B";
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

            _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Console.WriteLine("DEBUG - OnNavigatedFrom() in ViewB");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Console.WriteLine("DEBUG - OnNavigatedTo() in ViewB");
            Console.WriteLine("DEBUG - Estamos en {0}", _navigationService.GetNavigationUriPath());

            if (parameters.ContainsKey("id"))
                Title = (string)parameters["id"];
        }

        public ViewBViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
