using pos.Models;
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

            List<KeyValueModel> discounts = new List<KeyValueModel>()
            {
                new KeyValueModel("招牌拉麵買三送一","pos.Discounts.Ramen_buy_3_get_1_free"),
                new KeyValueModel("招牌拉麵搭可樂送水果一盤", "pos.Discounts.mainramen_cola_get_free_fruit"),
                new KeyValueModel("叉燒拉麵加豆腐$200", "pos.Discounts.porkramen_tofu_200"),
                new KeyValueModel("叉燒拉麵買兩個75折", "pos.Discounts.porkramen_buy2_get_75discount"),
                new KeyValueModel("味噌拉麵買兩個折30", "pos.Discounts.misoramen_buy2_discount30"),
                new KeyValueModel("醬油拉麵買兩個$300", "pos.Discounts.soysauceramen_buy2_300"),
                new KeyValueModel("鹽味拉麵搭可樂打75折", "pos.Discounts.saltramen_cola_get_75discount"),
                new KeyValueModel("味噌拉麵送溏心蛋", "pos.Discounts.misoramen_grt_egg_free"),
                new KeyValueModel("全場消費滿500折50", "pos.Discounts._500_get_50_free"),
                new KeyValueModel("全場消費滿1000打8折", "pos.Discounts._1000_get_80discount")
            };

            comboBox1.DataSource = discounts;
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }


        private void CheckedChage(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            NumericUpDown numericUpDown = (NumericUpDown)checkBox.Parent.Controls[1];
            numericUpDown.Value = checkBox.Checked ? 1 : 0;
            Item item = new Item(checkBox.Text, numericUpDown.Value);
            Order.AddOrder(item, comboBox1.SelectedValue.ToString());
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
            Order.AddOrder(item, comboBox1.SelectedValue.ToString());
        }


    }
}
