using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using System;
using TechnicalExercise.Services;
using TechnicalExercise.Services.Interfaces;
using TechnicalExercise.ViewModel;
using TechnicalExercise.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechnicalExercise
{
    public partial class App
    {
        public App() : this(null)
        {

        }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{nameof(MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterPopupDialogService();
            containerRegistry.RegisterForNavigation<NavigationPage>();

            //ViewModel
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();


            //services
            containerRegistry.RegisterSingleton<IDataStore, DataStore>();
        }
    }
}
