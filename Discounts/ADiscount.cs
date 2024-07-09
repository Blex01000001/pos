using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pos.Models.MenuModel;

namespace pos.Discounts
{
    abstract class ADiscount
    {
        protected List<Item> _itemlist;
        protected DiscountStrategy _discountStrategy;
        protected string _itemA;
        protected int _itemA_qt;
        protected string _itemB;
        protected int _itemB_qt;
        protected int _price;

        protected string _freeitem;
        protected int _freeitem_qt;
        protected int _minusPrice;
        protected int _discountPrice;
        protected float _discountRate;
        public ADiscount(List<Item> itemlist)
        {
            this._itemlist = itemlist;
        }

        public abstract void Discount();
    }
}
