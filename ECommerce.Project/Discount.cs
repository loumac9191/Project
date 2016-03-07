using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Project
{
    public class Discount
    {
        private decimal discountDue;

        public virtual decimal CurrentDiscountOffers(string discount)
        {
            if (discount == "TW3NTYFIV3")
            {
                discountDue = 0.75m;
                return discountDue;
            }
            else if (discount == "!F1FTY!")
            {
                discountDue = 0.5m;
                return discountDue;
            }
            else
            {
                discountDue = 1.00m;
                return discountDue;
            }
        } 
    }
}
