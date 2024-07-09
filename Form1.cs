using Newtonsoft.Json;
using pos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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
            string path = ConfigurationManager.AppSettings["MenuPath"];
            string str = File.ReadAllText(path);
            MenuModel menuModel = JsonConvert.DeserializeObject<MenuModel>(str);


            foreach (var item in menuModel.Menus)
            {
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                Label label = new Label();
                label.Text = item.Type.ToString();
                label.Width = 100;
                flowLayoutPanel.Width = 185;
                flowLayoutPanel.Height = 240;
                //flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
                flowLayoutPanel.Controls.Add(label);

                FlowLayoutPanel flowLayoutPanel_in = new FlowLayoutPanel();
                //flowLayoutPanel_in.BorderStyle = BorderStyle.FixedSingle;
                flowLayoutPanel_in.Height = 240;
                string[] strlist = item.Foods.Select(x => x.Name + "$" + x.Price).ToArray();
                string[] strlis1 = item.Foods.Select(x => x.Name + "$" + x.Price).ToArray();


                flowLayoutPanel_in.createItemByString(strlist, CheckedChage, ValueChage);

                flowLayoutPanel.Controls.Add(flowLayoutPanel_in);
                flowLayoutPanel1.Controls.Add(flowLayoutPanel);
            }
            EventHandlers.ReceivedFlowLayoutPanel += Panelupdate;

            List<KeyValueModel> discounts = menuModel.Discount.Select(x => new KeyValueModel(x.DiscountName, x)).ToList();

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
            Order.AddOrder(item, comboBox1.SelectedValue);
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
            Order.AddOrder(item, comboBox1.SelectedValue);
        }


    }
}
