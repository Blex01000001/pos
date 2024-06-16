using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    internal class misoramen_buy2_discount30 : ADiscount
    {
        public List<Item> _itemlist;
        public misoramen_buy2_discount30(List<Item> itemlist) : base(itemlist)
        {
            this._itemlist = itemlist;
        }

        public override void Discount()
        {
            Item item5 = _itemlist.FirstOrDefault(x => x.Name == "味噌拉麵" & x.Qt >= 2);
            if (item5 != null)
            {
                Item discount = new Item("味噌拉麵折扣$-30", item5.Qt / 2);
                _itemlist.Add(discount);
            }
        }
    }
}
