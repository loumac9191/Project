using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Project
{
    public class Checkout
    {
        private Basket basket;
        private Discount discount;
        private decimal basketTotal;
        private decimal discountMultiplier;

        public Checkout(Basket basketToCheckout, Discount discountToCheckout)
        {
            basket = basketToCheckout;
            discount = discountToCheckout;
            basketTotal = basket.CalculatePrice();
        }

        public decimal Discounter(string discountCodeInputFromUser)
        {
            discountMultiplier = discount.CurrentDiscountOffers(discountCodeInputFromUser);
            basketTotal = (basketTotal * discountMultiplier);
            return basketTotal;
        }
    }
}
