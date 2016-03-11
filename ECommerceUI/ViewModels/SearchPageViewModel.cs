using ECommerce.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EntityFramework.Project;
using System.Collections.ObjectModel;
using System.ServiceModel;

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

            if (retrievedItem.name == null || retrievedItem.name == "")
            {
                itemID = "N/A";
                itemName = "N/A";
                itemCategory = "N/A";
                itemPrice = "N/A";
                itemStockTotal = "N/A";
            }
            else
            {
                itemID = retrievedItem.item_id.ToString();
                itemName = retrievedItem.name;
                itemCategory = retrievedItem.category;
                itemPrice = retrievedItem.price.ToString();
                itemStockTotal = retrievedItem.quantityOfItem.ToString();
            }
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
        private IItemRepository _iIRepo;

        public SearchPageViewModel()
        {
            _stockChecker = new Stock();
            _iIRepo = new ItemRepository();
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

        private ICommand _getAllItems;

        public ICommand getAllItems
        {
            get 
            {
                if (_getAllItems == null)
                {
                    _getAllItems = new Command(GetAllItems, CanGetAllItems);
                }
                return _getAllItems; 
            }
            set { _getAllItems = value; }
        }

        private ObservableCollection<string> _allItemsInDb;

        public ObservableCollection<string> allItemsInDb
        {
            get { return _allItemsInDb; }
            set 
            {
                _allItemsInDb = value;
                OnPropertyChanged("allItemsInDb");
            }
        }

        public void GetAllItems()
        {
            EndpointAddress endpoint = new EndpointAddress("http://TRNLON11605:8081/ECommerce");
            IItemRepository _iIRepoForTypeOf = ChannelFactory<IItemRepository>.CreateChannel(new BasicHttpBinding(), endpoint);

            List<string> returnedItems = _iIRepo.GetStockList();
            allItemsInDb = new ObservableCollection<string>(returnedItems);
        }

        public bool CanGetAllItems()
        {
            return true;
        }        
    }
}
