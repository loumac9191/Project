using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerce.Project;

namespace ECommerceUI.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
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

        private ICommand _loginDetails;

        public ICommand loginDetails
        {
            get 
            {
                if (_loginDetails == null)
                {
                    _loginDetails = new Command(Login, CanLogin);
                }
                return _loginDetails; 
            }
            set { _loginDetails = value; }
        }

        private ICommand _toRegisterPage;

        public ICommand toRegisterPage
        {
            get 
            {
                if (_toRegisterPage == null)
                {
                    _toRegisterPage = new Command(ToRegisterPage, CanGoToRegisterPage);
                }
                return _toRegisterPage; 
            }
            set { _toRegisterPage = value; }
        }

        public LoginPageViewModel()
        {
            _loginController = new LoginController();
        }

        public LoginPageViewModel(LoginController loginController)
        {
            _loginController = loginController;
        }

        public void Login()
        {
            string result = _loginController.Login(username, password);

            if (result == String.Format("Welcome {0}", username))
            {
                MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
                vm.page = "SearchItemPage.xaml";
            }
            else
            {
                //Message Box?
            }           
        }

        public bool CanLogin()
        {
            if (username != null && password != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ToRegisterPage()
        {
            MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
            vm.page = "RegisterPage.xaml";
        }

        public bool CanGoToRegisterPage()
        {
            return true;
        }

        private void UpdateCommands()
        {
            ((Command)loginDetails).RaiseCanExecuteChanged();
        }
    }
}
