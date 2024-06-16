using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    internal class mainramen_cola_get_free_fruit : ADiscount
    {
        public List<Item> _itemlist;

        public mainramen_cola_get_free_fruit(List<Item> itemlist) : base(itemlist)
        {
            this._itemlist = itemlist;
        }

        public override void Discount()
        {
            Item item21 = _itemlist.FirstOrDefault(x => x.Name == "招牌拉麵" & x.Qt >= 1);
            Item item22 = _itemlist.FirstOrDefault(x => x.Name == "可樂" & x.Qt >= 1);
            if (item21 != null && item22 != null)
            {
                Item discount = new Item("水果(free)$0", Math.Min(item21.Qt, item22.Qt));
                _itemlist.Add(discount);
            }
        }
    }
}
