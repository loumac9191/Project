using ECommerce.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECommerceUI.ViewModels
{
    public class RemoveItemPageViewModel : BaseViewModel
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

        //all textboxs

        private string _itemID;

        public string itemID
        {
            get { return _itemID; }
            set 
            {
                _itemID = value;
                OnPropertyChanged("itemID");
            }
        }      

        private string _itemName;

        public string itemName
        {
            get { return _itemName; }
            set
            {
                _itemName = value;
                OnPropertyChanged("itemName");
            }
        }

        private string _itemPrice;

        public string itemPrice
        {
            get { return _itemPrice; }
            set
            {
                _itemPrice = value;
                OnPropertyChanged("itemPrice");
            }
        }

        private string _itemQuantity;

        public string itemQuantity
        {
            get { return _itemQuantity; }
            set 
            {
                _itemQuantity = value;
                OnPropertyChanged("itemQuantity");
            }
        }

        private ICommand _itemToRemoveFromDatabase;

        public ICommand itemToRemoveFromDatabase
        {
            get 
            {
                if (_itemToRemoveFromDatabase == null)
                {
                    _itemToRemoveFromDatabase = new Command(RemoveItemFromDatabase, CanRemoveItemFromDatabase);
                }
                return _itemToRemoveFromDatabase;
            }
            set { _itemToRemoveFromDatabase = value; }
        }

        public void RemoveItemFromDatabase()
        {

            //string result = _stockController.RemoveStock(itemName, itemQuantity);

            //if (result == String.Format("{0} has been removed from the Database.", itemName))
            //{
            //    //Something here to confirm that the item was removed from the database
            //    //itemName was successfully successfully removed from the database
            //}
            //else
            //{
            //    //Message Box?
            //    //error message
            //}
        }

        public bool CanRemoveItemFromDatabase()
        {
            if (itemID != null && itemName != null && itemPrice != null && itemQuantity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
