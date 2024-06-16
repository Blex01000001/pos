using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    internal class Ramen_buy_3_get_1_free : ADiscount
    {
        public List<Item> _itemlist;
        public Ramen_buy_3_get_1_free(List<Item> itemlist) : base(itemlist)
        {
            this._itemlist = itemlist;
        }

        public override void Discount()
        {
            Item item1 = _itemlist.FirstOrDefault(x => x.Name == "招牌拉麵" & x.Qt >= 3);
            if (item1 != null)
            {
                Item giftItem = new Item("招牌拉麵(free)$0", item1.Qt / 3);
                _itemlist.Add(giftItem);
            }
        }
    }
}
