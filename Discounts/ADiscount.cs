using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    abstract class ADiscount
    {
        protected List<Item> _itemlist;

        public ADiscount(List<Item> itemlist)
        {
            this._itemlist = itemlist;
        }

        public abstract void Discount();
    }
}
