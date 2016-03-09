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
            _loginController.Login(username, password);
        }

        public bool CanLogin()
        {
            //if (username == null && password == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            return true;
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
    }
}
