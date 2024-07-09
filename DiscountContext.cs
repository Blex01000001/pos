using pos.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pos.Models.MenuModel;

namespace pos
{
    public class DiscountContext
    {
        ADiscount aDiscount = null;

        public DiscountContext(List<Item> list, DiscountStrategy discountStrategy)
        {
            Type type = Type.GetType(discountStrategy.StrategyType);
            aDiscount = (ADiscount)Activator.CreateInstance(type, list, discountStrategy);
        }

        public void ContextInterface(List<Item> list)
        {
            aDiscount.Discount();
        }
    }
}
