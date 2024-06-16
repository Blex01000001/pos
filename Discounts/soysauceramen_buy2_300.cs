using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    internal class soysauceramen_buy2_300 : ADiscount
    {
        public List<Item> _itemlist;
        public soysauceramen_buy2_300(List<Item> itemlist) : base(itemlist)
        {
            this._itemlist = itemlist;
        }

        public override void Discount()
        {
            Item item6 = _itemlist.FirstOrDefault(x => x.Name == "醬油拉麵" & x.Qt >= 2);
            if (item6 != null)
            {
                Item discount = new Item("醬油拉麵折扣$-30", item6.Qt / 2);
                _itemlist.Add(discount);
            }
        }
    }
}
