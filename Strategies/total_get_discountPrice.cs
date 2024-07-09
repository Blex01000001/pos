using pos.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pos.Models.MenuModel;

namespace pos.Strategies
{
    internal class total_get_discountPrice : ADiscount
    {
        public total_get_discountPrice(List<Item> itemlist, DiscountStrategy discountStrategy) : base(itemlist)
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
            if (_itemlist.Sum(x => x.Subtotal) >= 500)
            {
                Item discount = new Item("滿" + _price + "折扣" + _minusPrice + "$-" + _minusPrice, _itemlist.Sum(x => x.Subtotal) / _price);
                _itemlist.Add(discount);
            }
        }
    }
}
