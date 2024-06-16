using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pos
{
    internal class Discount
    {
        public static void DiscountFoodList(List<Item> list, string option)
        {
            //招牌拉麵買三送一
            //招牌拉麵搭可樂送水果一盤
            //叉燒拉麵加豆腐$200
            //叉燒拉麵買兩個75折
            //味噌拉麵買兩個折30
            //醬油拉麵買兩個$300
            //鹽味拉麵搭可樂打75折
            //味噌拉麵送溏心蛋
            //全場消費滿500折50
            //全場消費滿1000打8折
            list.RemoveAll(x => x.Name.Contains("free"));
            list.RemoveAll(x => x.Name.Contains("折扣"));
            DiscountFactory.CreateDiscount(list, option).Discount();

            ShowPanel.ShowDetailPanel(list);
        }
    }
}
