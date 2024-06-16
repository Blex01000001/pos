using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos
{
    public static class ShowPanel
    {
        public static void Show()
        {
            //Order.checkoutList;




        }
        public static void ShowDetailPanel(List<Item> checkoutList)
        {
            FlowLayoutPanel OutsidePanel = new FlowLayoutPanel();
            OutsidePanel.Size = new System.Drawing.Size(300, 400);
            foreach (var item in checkoutList)
            {
                FlowLayoutPanel Panel = new FlowLayoutPanel();
                OutsidePanel.Controls.Add(Panel);
                Panel.Size = new System.Drawing.Size(300, 15);
                Panel.CreatByString_Width(item.Name, 120);
                Panel.CreatByString_Width(item.Price.ToString(), 50);
                Panel.CreatByString_Width(item.Qt.ToString(), 50);
                Panel.CreatByString_Width(item.Subtotal.ToString(), 50);
            }
            EventHandlers.UpdatedPanel(OutsidePanel);
        }

    }
}
