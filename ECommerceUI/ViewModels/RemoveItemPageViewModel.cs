using ECommerce.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECommerceUI.ViewModels
{
    public class RemoveItemPageViewModel
    {
        private ICommand _searchFor;

        public ICommand searchFor
        {
            get
            {
                if (_searchFor == null)
                {
                    _searchFor = new Command(SearchFor, CanSearchFor);
                }
                return _searchFor;
            }
            set { _searchFor = value; }
        }

        private ICommand _addItem;

        public ICommand addItem
        {
            get
            {
                if (_addItem == null)
                {
                    _addItem = new Command(AddItem, CanAddItem);
                }
                return _addItem;
            }
            set { _addItem = value; }
        }

        private ICommand _removeItem;

        public ICommand removeItem
        {
            get
            {
                if (_removeItem == null)
                {
                    _removeItem = new Command(RemoveItem, CanRemoveItem);
                }
                return _removeItem;
            }
            set { _removeItem = value; }
        }
        
        private ICommand _logout;

        public ICommand logout
        {
            get
            {
                if (_logout == null)
                {
                    _logout = new Command(Logout, CanLogout);
                }
                return _logout;
            }
            set { _logout = value; }
        }

        public void SearchFor()
        {
            MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
            vm.page = "SearchItemPage.xaml";
        }

        public bool CanSearchFor()
        {
            return true;
        }

        public void AddItem()
        {
            MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
            vm.page = "AddStockPage.xaml";
        }

        public bool CanAddItem()
        {
            return true;
        }

        public void RemoveItem()
        {

        }

        public bool CanRemoveItem()
        {
            return true;
        }

        //private void UpdateCommands()
        //{
        //    ((Command)registerDetails).RaiseCanExecuteChanged();
        //}

        public void Logout()
        {
            MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
            vm.page = "LoginPage.xaml";
        }

        public bool CanLogout()
        {
            return true;
        }

        private LoginController _loginController;

        public RemoveItemPageViewModel()
        {
            _loginController = new LoginController();
        }


    }
}
