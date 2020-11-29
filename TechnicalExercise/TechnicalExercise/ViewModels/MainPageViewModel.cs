using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using TechnicalExercise.Models;
using TechnicalExercise.Services.Interfaces;
using TechnicalExercise.ViewModels;

namespace TechnicalExercise.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IDataStore _dataStore;

        #region Commands
        public DelegateCommand<string> OrderByCommand { get; set; }
        public DelegateCommand SearchTextChanged { get; set; }
        #endregion

        #region Properties
        private ObservableCollection<UserModel> _users;
        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        public bool IsAscending { get; set; }
        public string SortBy { get; set; }

        private Field _searchText;
        public Field SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        private string _notValidMessageError;
        public string NotValidMessageError
        {
            get { return _notValidMessageError; }
            set { SetProperty(ref _notValidMessageError, value); }
        }

        #endregion

        public MainPageViewModel(INavigationService navigationService, IDialogService dialogService, IDataStore dataStore) :base(navigationService, dialogService)
        {
            SearchText = new Field();
            IsAscending = true;
            _dataStore = dataStore;
            Users = new ObservableCollection<UserModel>();
            OrderByCommand = new DelegateCommand<string>(ExecutedOrderByCommand);
            SearchTextChanged = new DelegateCommand(ExecutedSearchTextChange);
            GetUserList();
        }

        private async void ExecutedSearchTextChange()
        {
            if (IsValidSearch() && SearchText.Value.Count() > 2 && SearchText.Value.Count() < 29)
            {
                List<UserModel> filteredList = new List<UserModel>();

                var str = SearchText.Value.ToLower().Split(new string[] { "and" }, StringSplitOptions.None);
                foreach (var item in str)
                {
                    string txt = item.Trim();

                    if (filteredList.Count() == 0)
                    {
                        var data = await _dataStore.FilterAsync(txt);
                        if (data.Count() > 0)
                            filteredList.AddRange(data);
                    }
                    else
                    {
                        var data = filteredList.Where(t =>
                                t.Name.ToLower().Contains(txt) ||
                                t.Email.ToLower().Contains(txt) ||
                                t.Phone.Contains(txt) ||
                                t.Age.ToString().Contains(txt) ||
                                t.Postal.Contains(txt)
                               );
                        if (data.Count() > 0)
                        {
                            filteredList = new List<UserModel>();
                            filteredList.AddRange(data);
                        }
                        else
                        {
                            filteredList.Clear();
                            break;
                        }
                    }
                }
                Users.Clear();
                foreach (var d in filteredList)
                {
                    Users.Add(d);
                }
                RaisePropertyChanged(nameof(Users));
            }
        }

        private void ExecutedOrderByCommand(string column)
        {
            if (!SortBy.Equals(column))
                IsAscending = false;

            if (!IsAscending)
                Users = column == "Name" ? new ObservableCollection<UserModel>(Users.OrderBy(c => c.Name)) :
                    column == "Email" ? new ObservableCollection<UserModel>(Users.OrderBy(c => c.Email)) :
                    column == "Phone" ? new ObservableCollection<UserModel>(Users.OrderBy(c => c.Phone)) :
                    column == "Age" ? new ObservableCollection<UserModel>(Users.OrderBy(c => c.Age)) :
                    column == "Postal" ? new ObservableCollection<UserModel>(Users.OrderBy(c => c.Postal)) : 
                    new ObservableCollection<UserModel>(Users.OrderBy(c => c.Name));
            else
                Users = column == "Name" ? new ObservableCollection<UserModel>(Users.OrderByDescending(c => c.Name)) :
                    column == "Email" ? new ObservableCollection<UserModel>(Users.OrderByDescending(c => c.Email)) :
                    column == "Phone" ? new ObservableCollection<UserModel>(Users.OrderByDescending(c => c.Phone)) :
                    column == "Age" ? new ObservableCollection<UserModel>(Users.OrderByDescending(c => c.Age)) :
                    column == "Postal" ? new ObservableCollection<UserModel>(Users.OrderByDescending(c => c.Postal)) :
                    new ObservableCollection<UserModel>(Users.OrderByDescending(c => c.Name));

            IsAscending = !IsAscending;
            SortBy = column;
        }

        private async void GetUserList()
        {
            var users = await _dataStore.GetAsync();
            SortBy = "Name";
            Users = new ObservableCollection<UserModel>(users.OrderBy(c=>c.Name));
        }

        private bool IsValidSearch()
        {
            bool result = false;
            bool isNull = string.IsNullOrEmpty(SearchText.Value);
            if (!isNull)
            {
                const string specialCharactersRegex = "^[^<>{}\"/|;:,~!?#$%^=&*\\]\\\\()\\[¿§«»ω⊙¤°℃℉€¥£¢¡®©_+]*$";
                bool IsValid = (Regex.IsMatch(SearchText.Value, specialCharactersRegex));
                if (!IsValid)
                {
                    SearchText.IsNotValid = true;
                    NotValidMessageError = "Special characters not allowed";
                    result = false;
                }
                else
                {
                    SearchText.IsNotValid = false;
                    result = true;
                }
                RaisePropertyChanged(nameof(SearchText));
            }
            else
            {
                GetUserList();
            }
            return result;
        }
    }
}
