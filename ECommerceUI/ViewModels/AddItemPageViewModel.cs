using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Project;
using System.Windows.Input;

namespace ECommerceUI.ViewModels
{
    public class AddItemPageViewModel : BaseViewModel
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

        private Stock _stockController;

        public AddItemPageViewModel()
        {
            _stockController = new Stock();
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

        public void Logout()
        {
            MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
            vm.page = "LoginPage.xaml";
        }

        public bool CanLogout()
        {
            return true;
        }

        //add item form, including all fields and command button

        private ICommand _addItemToDatabase;

        public ICommand addItemToDatabase
        {
            get
            {
                if (_addItemToDatabase == null)
                {
                    _addItemToDatabase = new Command(AddItemToDatabase, CanAddItemToDatabase);
                }
                return _addItemToDatabase;
            }
            set { _addItemToDatabase = value; }
        }

        public void AddItemToDatabase()
        {
            string result = _stockController.AddStock(itemName,itemCategory,itemDescription, Convert.ToDecimal(itemPrice),Convert.ToInt32(itemQuantity));

            if (result.Contains(itemName))
            {
                string resultMessage = String.Format("{0} was succesfully added to the database, please check the stock levels through the Search feature", itemName);
                itemName = "";
                itemCategory = "";
                itemDescription = "";
                itemPrice = "";
                itemQuantity = "";
            }
            //if (result == String.Format("{0} has been added to the Database", itemName))
            //{
            //    //Something here to confirm that this was added to data
            //    //itemName was successfully added to the database


            //}
            //else if(result == String.Format("There are now a total of {0} of {1} in stock", totalOfItem, nameOfItem)
            //{
            //    //a certain quantity has been added
            //}
            //else
            //{
            //    //else something went wrong, dont think this is possible
            //}
        }

        public bool CanAddItemToDatabase()
        {
            return true;
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

        private string _itemCategory;

        public string itemCategory
        {
            get { return _itemCategory; }
            set
            {
                _itemCategory = value;
                OnPropertyChanged("itemCategory");
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

        private string _itemDescription;

        public string itemDescription
        {
            get { return _itemDescription; }
            set
            {
                _itemDescription = value;
                OnPropertyChanged("itemDescription");
            }
        }
    }
}
