using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace pos
{
    public partial class Form1 : Form
    {
        List<string> checkoutList = new List<string>();
        //string[] title = { "品項_110", "價格_60", "數量_50", "小計_50" };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel5.Controls.Clear();

            int total = 0;
            total += flowLayoutPanel1.totalByCheckbox();
            total += flowLayoutPanel2.totalByCheckbox();
            total += flowLayoutPanel3.totalByCheckbox();
            total += flowLayoutPanel4.totalByCheckbox();
            label2.Text = total.ToString();

            checkoutList.Clear();
            checkoutList.AddRange(flowLayoutPanel1.returnCheckedText());
            checkoutList.AddRange(flowLayoutPanel3.returnCheckedText());
            checkoutList.AddRange(flowLayoutPanel2.returnCheckedText());
            checkoutList.AddRange(flowLayoutPanel4.returnCheckedText());

            for (int i = 0; i < checkoutList.Count; i++)
            {
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel5.Controls.Add(flowLayoutPanel);
                flowLayoutPanel.Size = new System.Drawing.Size(300, 15);

                Label name1 = new Label();
                name1.Text = checkoutList[i].Split('$')[0];
                name1.Width = 110;
                flowLayoutPanel.Controls.Add(name1);

                Label price = new Label();
                price.Text = checkoutList[i].Split('$')[1];
                price.Width = 60;
                flowLayoutPanel.Controls.Add(price);

                Label quantity = new Label();
                quantity.Text = "1";
                quantity.Width = 50;
                flowLayoutPanel.Controls.Add(quantity);

                Label subtotal = new Label();
                subtotal.Text = checkoutList[i].Split('$')[1];
                subtotal.Width = 50;
                flowLayoutPanel.Controls.Add(subtotal);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] foods = { "招牌拉麵$200", "叉燒拉麵$170", "味噌拉麵$150", "醬油拉麵$165", "鹽味拉麵$155" };
            string[] dish = { "日式炸雞$150", "涼拌小黃瓜$90", "皮蛋豆腐$60", "涼拌豆芽菜$60", "炸豆腐$70", "溏心蛋$50", "炸物拼盤$220", };
            string[] drinks = { "可樂$100", "雪碧$100", "紅茶$80", "綠茶$80", "爽健美茶$70", "法國進口氣泡水$300" };
            string[] others = { "布朗尼$150", "抹茶冰淇淋$50", "草莓蛋糕$90", "草莓大福$70", "當季水果$100", "黃金開口笑$500", };
            flowLayoutPanel1.createCheckboxByString(foods);
            flowLayoutPanel2.createCheckboxByString(drinks);
            flowLayoutPanel3.createCheckboxByString(dish);
            flowLayoutPanel4.createCheckboxByString(others);
            //string word = "Hello1234";
            //Console.WriteLine(word.GetWordCount());

            //FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            //flowLayoutPanel5.Controls.Add(flowLayoutPanel);
            //flowLayoutPanel.Size = new System.Drawing.Size(300, 20);

            //for (int i = 0; i < title.Length; i++)
            //{
            //    Label label = new Label();
            //    label.Text = title[i].Split('_')[0];
            //    label.Width = int.Parse(title[i].Split('_')[1]);
            //    flowLayoutPanel.Controls.Add(label);
            //}
        }

    }
}
