using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    internal class saltramen_cola_get_75discount : ADiscount
    {
        public List<Item> _itemlist;
        public saltramen_cola_get_75discount(List<Item> itemlist) : base(itemlist)
        {
            this._itemlist = itemlist;
        }

        public override void Discount()
        {
            Item item71 = _itemlist.FirstOrDefault(x => x.Name == "鹽味拉麵" & x.Qt >= 1);
            Item item72 = _itemlist.FirstOrDefault(x => x.Name == "可樂" & x.Qt >= 1);
            if (item71 != null && item72 != null)
            {
                Item discount = new Item("鹽味拉麵搭可樂折扣$-64", Math.Min(item71.Qt, item72.Qt));
                _itemlist.Add(discount);
            }
        }
    }
}
