using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    internal class _500_get_50_free : ADiscount
    {
        public List<Item> _itemlist;

        public _500_get_50_free(List<Item> itemlist) : base(itemlist)
        {
            this._itemlist = itemlist;
        }

        public override void Discount()
        {
            if (_itemlist.Sum(x => x.Subtotal) >= 500)
            {
                Item discount = new Item("滿500折扣50$-50", _itemlist.Sum(x => x.Subtotal) / 500);
                _itemlist.Add(discount);
            }
        }
    }
}
