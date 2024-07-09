using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.Models
{
    public class MenuModel
    {

        public Menu[] Menus { get; set; }
        public DiscountStrategy[] Discount { get; set; }

        public class Menu
        {
            public string Type { get; set; }
            public Food[] Foods { get; set; }
        }

        public class Food
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public class DiscountStrategy
        {
            public string DiscountName { get; set; }
            public string StrategyType { get; set; }
            public Inputcondition InputCondition { get; set; }
            public DiscountResult Discount { get; set; }
        }

        public class Inputcondition
        {
            public string itemA { get; set; }
            public int itemA_qt { get; set; }
            public string itemB { get; set; }
            public int itemB_qt { get; set; }
            public int price { get; set; }
        }

        public class DiscountResult
        {
            public string Freeitem { get; set; }
            public int qt { get; set; }
            public int minusPrice { get; set; }
            public int discountPrice { get; set; }
            public float discountRate { get; set; }
        }

    }
}
