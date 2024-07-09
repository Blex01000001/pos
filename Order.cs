using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pos.Models.MenuModel;

namespace pos
{
    public static class Order
    {
        public static List<Item> checkoutList = new List<Item>();
        public static void AddOrder(Item item, Object discountStrategy)
        {
            //ShowList(checkoutList);
            Item food = checkoutList.FirstOrDefault(x => x.Name == item.Name);
            if (food == null)
            {
                Console.WriteLine("NEW");
                checkoutList.Add(item); //新增
                //ShowList(checkoutList);
                return;
            }
            if (food.Qt == 0)
            {
                Console.WriteLine("Delete");
                Console.WriteLine(checkoutList.Remove(food));
            }
            else
            {
                Console.WriteLine("Modify");
                food.Qt = item.Qt;  //修改
                food.Subtotal = food.Qt * food.Price;
            }

            Discount.DiscountFoodList(checkoutList, discountStrategy);
            //DiscountContext discountContext = new DiscountContext(checkoutList, option);
            //discountContext.ContextInterface(checkoutList);

            //Discount.DiscountFoodList(checkoutList, option);
        }




    }
}
