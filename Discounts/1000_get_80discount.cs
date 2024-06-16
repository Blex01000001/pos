using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    internal class _1000_get_80discount : ADiscount
    {
        public List<Item> _itemlist;

        public _1000_get_80discount(List<Item> itemlist) : base(itemlist)
        {
            this._itemlist = itemlist;
        }

        public override void Discount()
        {
            if (_itemlist.Sum(x => x.Subtotal) >= 1000)
            {
                Item discount = new Item("滿1000折扣$-" + (_itemlist.Sum(x => x.Subtotal) * 0.2).ToString(), 1);
                _itemlist.Add(discount);
            }
        }
    }
}
