using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Project;
using System.Windows.Input;

namespace ECommerceUI.ViewModels
{
    public class AddItemPageViewModel
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
        
        public void SearchFor()
        {
            MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
            vm.page = "SearchItemPage.xaml";
        }

        public bool CanSearchFor()
        {
            return true;
        }

        private LoginController _loginController;

        public AddItemPageViewModel()
        {
            _loginController = new LoginController();
        }

        public void AddItem()
        {

        }

        public bool CanAddItem()
        {
            return true;
        }

        public void RemoveItem()
        {
            MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
            vm.page = "RemoveStockPage.xaml";
        }

        public bool CanRemoveItem()
        {
            return true;
        }

        //private void UpdateCommands()
        //{
        //    ((Command)registerDetails).RaiseCanExecuteChanged();
        //}
    }
}
