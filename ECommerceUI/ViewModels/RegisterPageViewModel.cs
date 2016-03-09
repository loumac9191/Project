using ECommerce.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ECommerceUI.ViewModels
{
    public class RegisterPageViewModel : BaseViewModel
    {
        private LoginController _loginController;

        private string _username;

        public string username
        {
            get { return _username; }
            set 
            {
                _username = value;
                OnPropertyChanged("username");
                UpdateCommands();
            }
        }

        private string _password;

        public string password
        {
            get { return _password; }
            set 
            {
                _password = value;
                OnPropertyChanged("password");
                UpdateCommands();
            }
        }

        private string _firstname;

        public string firstname
        {
            get { return _firstname; }
            set 
            {
                _firstname = value;
                OnPropertyChanged("firstname");
                UpdateCommands();
            }
        }

        private string _lastname;

        public string lastname
        {
            get { return _lastname; }
            set 
            {
                _lastname = value;
                OnPropertyChanged("lastname");
                UpdateCommands();
            }
        }

        private ICommand _registerDetails;

        public ICommand registerDetails
        {
            get 
            {
                if (_registerDetails == null)
                {
                    _registerDetails = new Command(Register, CanRegister);
                }
                return _registerDetails;
            }
            set { _registerDetails = value; }
        }

        private ICommand _toLoginPage;

        public ICommand toLoginPage
        {
            get 
            {
                if (_toLoginPage == null)
                {
                    _toLoginPage = new Command(ToLoginPage, CanGoToLoginPage);
                }
                return _toLoginPage; 
            }
            set { _toLoginPage = value; }
        }

        public RegisterPageViewModel()
        {
            _loginController = new LoginController();
        }
  
        public RegisterPageViewModel(LoginController loginController)
        {
            _loginController = loginController;
        }

        public void Register()
        {
            string result = _loginController.Register(firstname, lastname, username, password);

            if (result == String.Format("{0} has been added to the database", username))
            {
                MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
                vm.page = "SearchItemPage.xaml";
            }
            else
            {
                //Message Box?
            } 
        }

        public bool CanRegister()
        {
            if (username != null && password != null && firstname != null && lastname != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ToLoginPage()
        {
            MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
            vm.page = "LoginPage.xaml";
        }

        public bool CanGoToLoginPage()
        {
            return true;
        }

        private void UpdateCommands()
        {
            ((Command)registerDetails).RaiseCanExecuteChanged();
        }
    }
}
