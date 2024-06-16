using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Discounts
{
    internal class porkramen_tofu_200 : ADiscount
    {
        public List<Item> _itemlist;
        public porkramen_tofu_200(List<Item> itemlist) : base(itemlist)
        {
            this._itemlist = itemlist;
        }

        public override void Discount()
        {
            Item item31 = _itemlist.FirstOrDefault(x => x.Name == "叉燒拉麵" & x.Qt >= 1);
            Item item32 = _itemlist.FirstOrDefault(x => x.Name == "豆腐" & x.Qt >= 1);
            if (item31 != null && item32 != null)
            {
                Item discount = new Item("叉燒拉麵加豆腐折扣$-30", Math.Min(item31.Qt, item32.Qt));
                _itemlist.Add(discount);
            }
        }
    }
}
