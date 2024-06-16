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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace pos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] foods = { "招牌拉麵$200", "叉燒拉麵$170" +
                    "", "味噌拉麵$150", "醬油拉麵$165", "鹽味拉麵$155" };
            string[] dish = { "炸雞$150", "小黃瓜$90", "豆腐$60", "豆芽菜$60", "炸豆腐$70", "溏心蛋$50", "炸物$220", };
            string[] drinks = { "可樂$100", "雪碧$100", "紅茶$80", "綠茶$80", "爽健美茶$70", "氣泡水$300" };
            string[] others = { "布朗尼$150", "冰淇淋$50", "草莓蛋糕$90", "草莓大福$70", "水果$100" };
            flowLayoutPanel1.createItemByString(foods, CheckedChage, ValueChage);
            flowLayoutPanel2.createItemByString(drinks, CheckedChage, ValueChage);
            flowLayoutPanel3.createItemByString(dish, CheckedChage, ValueChage);
            flowLayoutPanel4.createItemByString(others, CheckedChage, ValueChage);
            EventHandlers.ReceivedFlowLayoutPanel += Panelupdate;
        }


        private void CheckedChage(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            NumericUpDown numericUpDown = (NumericUpDown)checkBox.Parent.Controls[1];
            numericUpDown.Value = checkBox.Checked ? 1 : 0;
            Item item = new Item(checkBox.Text, numericUpDown.Value);
            Order.AddOrder(item, comboBox1.Text);
        }

        private void Panelupdate(object sender, FlowLayoutPanel e)
        {
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel5.Controls.Add(e);
        }

        private void ValueChage(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            CheckBox checkBox = (CheckBox)numericUpDown.Parent.Controls[0];
            checkBox.Checked = numericUpDown.Value == 0 ? false : true;
            Item item = new Item(checkBox.Text, (int)numericUpDown.Value);
            Order.AddOrder(item, comboBox1.Text);
        }


    }
}
