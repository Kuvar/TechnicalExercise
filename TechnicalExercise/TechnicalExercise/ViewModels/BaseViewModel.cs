using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalExercise.ViewModels
{
    public class BaseViewModel : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IDialogService DialogService { get; private set; }
        private IPageDialogService PageDialogService { get; set; }
        public DelegateCommand<object> BackCommand { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private bool _isLoadingData;
        public bool IsLoadingData
        {
            get { return _isLoadingData; }
            set { SetProperty(ref _isLoadingData, value); }
        }

        private List<System.ComponentModel.DataAnnotations.ValidationResult> _errorList;
        public List<System.ComponentModel.DataAnnotations.ValidationResult> ErrorList
        {
            get { return _errorList; }
            set { SetProperty(ref _errorList, value); }
        }

        public BaseViewModel()
        {
            BackCommand = new DelegateCommand<object>(OnGoingBack);
        }

        public BaseViewModel(INavigationService navigationService) : this()
        {
            NavigationService = navigationService;
        }

        public BaseViewModel(INavigationService navigationService, IDialogService dialogService) : this()
        {
            NavigationService = navigationService;
            DialogService = dialogService;
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public void Initialize(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (IsNewNavigation(parameters))
            {
                
            }
        }

        protected bool IsNewNavigation(INavigationParameters parameters)
        {
            return parameters.GetNavigationMode() == NavigationMode.New;
        }

        protected bool IsBackNavigation(INavigationParameters parameters)
        {
            return parameters.GetNavigationMode() == NavigationMode.Back;
        }

        private async void OnGoingBack(object animated = null)
        {
            try
            {
                await NavigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
