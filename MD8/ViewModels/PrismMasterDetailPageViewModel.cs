using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MD8.ViewModels
{
    public class PrismMasterDetailPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;

        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand =>   
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteCommandName));

        void ExecuteCommandName(string page)
        {
            Console.WriteLine("PrismMasterDetailPageViewModel - ExecuteCommandName() Vamos a {0}", page);
            //_navigationService.NavigateAsync(new Uri(page));
            //_navigationService.NavigateAsync(page, useModalNavigation: false);            
            //_navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
            _navigationService.NavigateAsync(page);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Console.WriteLine("PrismMasterDetailPageViewModel - OnNavigatedTo  parameters {0}", parameters.ToString());
        }

        public PrismMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
