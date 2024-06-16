using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    internal class porkramen_buy2_get_75discount : ADiscount
    {
        public List<Item> _itemlist;
        public porkramen_buy2_get_75discount(List<Item> itemlist) : base(itemlist)
        {
            this._itemlist = itemlist;
        }

        public override void Discount()
        {
            Item item4 = _itemlist.FirstOrDefault(x => x.Name == "叉燒拉麵" & x.Qt >= 2);
            if (item4 != null)
            {
                Item discount = new Item("叉燒拉麵折扣$-85", item4.Qt / 2);
                _itemlist.Add(discount);
            }

        }
    }
}
