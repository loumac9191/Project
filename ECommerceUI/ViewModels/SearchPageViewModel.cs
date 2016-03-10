using ECommerce.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EntityFramework.Project;

namespace ECommerceUI.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
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

        private ICommand _searchForItem;

        public ICommand searchForItem
        {
            get 
            {
                if (_searchForItem == null)
                {
                    _searchForItem = new Command(GetItem, CanGetItem);
                }
                return _searchForItem; 
            }
            set { _searchForItem = value; }
        }

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

        private string _itemStockTotal;

        public string itemStockTotal
        {
            get { return _itemStockTotal; }
            set 
            {
                _itemStockTotal = value;
                OnPropertyChanged("itemStockTotal");
            }
        }
        

        private string _itemSearched;

        public string itemSearched
        {
            get { return _itemSearched; }
            set { _itemSearched = value; }
        }

        public void GetItem()
        {
           item retrievedItem = _stockChecker.StockRetriever(itemSearched);
           //need to add id and quantity to this
           
           itemID = retrievedItem.item_id.ToString(); 
           itemName = retrievedItem.name;
           itemCategory = retrievedItem.category;
           itemPrice = retrievedItem.price.ToString();
           itemStockTotal = retrievedItem.quantityOfItem.ToString(); 

        }

        public bool CanGetItem()
        {
            return true;
        }
        
        public void SearchFor()
        {

        }

        public bool CanSearchFor()
        {
            return true;
        }

        private Stock _stockChecker;

        public SearchPageViewModel()
        {
            _stockChecker = new Stock();
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
            MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
            vm.page = "RemoveStockPage.xaml";
        }

        public bool CanRemoveItem()
        {
            return true;
        }

        public void Logout()
        {
            MainViewModel vm = App.Current.MainWindow.DataContext as MainViewModel;
            vm.page = "LoginPage.xaml";
        }

        public bool CanLogout()
        {
            return true;
        }
    }
}
