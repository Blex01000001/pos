using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    internal class misoramen_grt_egg_free : ADiscount
    {
        public List<Item> _itemlist;
        public misoramen_grt_egg_free(List<Item> itemlist) : base(itemlist)
        {
            this._itemlist = itemlist;
        }

        public override void Discount()
        {
            Item item8 = _itemlist.FirstOrDefault(x => x.Name == "味噌拉麵" & x.Qt >= 1);
            if (item8 != null)
            {
                Item discount = new Item("溏心蛋(free)$0", item8.Qt / 1);
                _itemlist.Add(discount);
            }
        }
    }
}
