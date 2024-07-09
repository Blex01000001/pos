using pos.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pos.Models.MenuModel;

namespace pos.Strategies
{
    internal class buy_A_B_get_discountRate : ADiscount
    {
        public buy_A_B_get_discountRate(List<Item> itemlist, DiscountStrategy discountStrategy) : base(itemlist)
        {
            this._discountStrategy = discountStrategy;
            this._itemlist = itemlist;
            this._itemA = _discountStrategy.InputCondition.itemA.ToString();
            this._itemA_qt = _discountStrategy.InputCondition.itemA_qt;
            this._itemB = _discountStrategy.InputCondition.itemB.ToString();
            this._itemB_qt = _discountStrategy.InputCondition.itemB_qt;
            this._price = _discountStrategy.InputCondition.price;

            this._freeitem = discountStrategy.Discount.Freeitem.ToString();
            this._freeitem_qt = _discountStrategy.Discount.qt;
            this._minusPrice = _discountStrategy.Discount.minusPrice;
            this._discountPrice = _discountStrategy.Discount.discountPrice;
            this._discountRate = _discountStrategy.Discount.discountRate;
        }

        public override void Discount()
        {
            Item item71 = _itemlist.FirstOrDefault(x => x.Name == _itemA & x.Qt >= _itemA_qt);
            Item item72 = _itemlist.FirstOrDefault(x => x.Name == _itemB & x.Qt >= _itemB_qt);
            if (item71 != null && item72 != null)
            {
                float mPrice = (item71.Price + item72.Price) * (1 - _discountRate);
                Item discount = new Item(_itemA + "搭" + _itemB + "折扣$-" + (int)mPrice, Math.Min(item71.Qt, item72.Qt));
                _itemlist.Add(discount);
            }

        }
    }
}
