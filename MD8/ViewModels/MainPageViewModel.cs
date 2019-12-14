using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD8.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));

        void ExecuteNavigateCommand(string parameter)
        {
            Console.WriteLine("MainPageViewModel - ExecuteNavigateCommand() Vamos a {0}", parameter);
            NavigationService.NavigateAsync("ViewA");
        }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}
