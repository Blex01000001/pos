using pos.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace pos
{
    internal class DiscountFactory
    {
        public static ADiscount CreateDiscount(List<Item> _itemlist, string discountType)
        {
            ADiscount aDiscount = null;
            switch (discountType)
            {
                case "招牌拉麵買三送一":
                    aDiscount = new Ramen_buy_3_get_1_free(_itemlist);
                    break;
                case "招牌拉麵搭可樂送水果一盤":
                    aDiscount = new mainramen_cola_get_free_fruit(_itemlist);
                    break;
                case "叉燒拉麵加豆腐$200":
                    aDiscount = new porkramen_tofu_200(_itemlist);
                    break;
                case "叉燒拉麵買兩個75折":
                    aDiscount = new porkramen_buy2_get_75discount(_itemlist);
                    break;
                case "味噌拉麵買兩個折30":
                    aDiscount = new misoramen_buy2_discount30(_itemlist);
                    break;
                case "醬油拉麵買兩個$300":
                    aDiscount = new soysauceramen_buy2_300(_itemlist);
                    break;
                case "鹽味拉麵搭可樂打75折":
                    aDiscount = new saltramen_cola_get_75discount(_itemlist);
                    break;
                case "味噌拉麵送溏心蛋":
                    aDiscount = new misoramen_grt_egg_free(_itemlist);
                    break;
                case "全場消費滿500折50":
                    aDiscount = new _500_get_50_free(_itemlist);
                    break;
                case "全場消費滿1000打8折":
                    aDiscount = new _1000_get_80discount(_itemlist);
                    break;
                default:
                    aDiscount = new NoDiscount(_itemlist);
                    break;
            }
            return aDiscount;
        }
    }
}
