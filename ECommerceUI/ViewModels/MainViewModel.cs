using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _page;

        public string page
        {
            get { return _page; }
            set 
            {
                _page = value;
                OnPropertyChanged("page");
            }
        }

        public MainViewModel()
        {
            //_page = "SearchItemPage.xaml";
            _page = "LoginPage.xaml";
        }
    }
}
