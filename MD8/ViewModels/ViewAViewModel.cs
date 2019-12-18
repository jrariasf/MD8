using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MD8.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        private string _title = "View A";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _mitexto = "inicializamos";
        public string mitexto
        {
            get { return _mitexto; }
            set { SetProperty(ref _mitexto, value); }
        }

        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));

        void ExecuteNavigateCommand(string parameter)  // Equivale al Navigate() del vídeo de Brian Lagunas
        {
            Console.WriteLine("ViewAViewModel - ExecuteNavigateCommand() Vamos a {0}", parameter);          
            _navigationService.NavigateAsync(parameter);                        
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Console.WriteLine("DEBUG - ViewAVM: Estamos en {0}", _navigationService.GetNavigationUriPath());
        }

        public ViewAViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
    }
}
