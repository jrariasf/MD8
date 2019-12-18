using Prism;
using Prism.Ioc;
using MD8.ViewModels;
using MD8.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MD8
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
            //await NavigationService.NavigateAsync("NavigationPage/ViewA");
            //await NavigationService.NavigateAsync("ViewA");
            //await NavigationService.NavigateAsync("NavigationPage/PrismMasterDetailPage"); //NOOOO
            //await NavigationService.NavigateAsync("NavigationPage/PrismMasterDetailPage/ViewA/ViewB");
            //await NavigationService.NavigateAsync("PrismMasterDetailPage/NavigationPage/ViewA/ViewC/ViewB/ViewA");
            await NavigationService.NavigateAsync("PrismMasterDetailPage/NavigationPage/ViewA");
            //await NavigationService.NavigateAsync("/PrismMasterDetailPage/NavigationPage/ViewA");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismMasterDetailPage, PrismMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
            containerRegistry.RegisterForNavigation<ViewC, ViewCViewModel>();
        }
    }
}
