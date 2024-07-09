using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos
{
    internal static class Extension
    {
        public static int GetWordCount(this string word)
        {
            int count = 0;
            foreach (char c in word)
            {
                if (!Char.IsDigit(c))
                {
                    count++;
                }
            }
            return count;
        }

        public static event EventHandler<EventArgs> updatePanelList;
        public static void updatePanel(this FlowLayoutPanel flowLayoutPanel, EventArgs message)
        {
            updatePanelList.Invoke(null, message);
        }
        public static void createItemByString(this FlowLayoutPanel flowLayoutPanel, string[] stringList, EventHandler checkedChange, EventHandler valueChage)
        {
            for (int i = 0; i < stringList.Length; i++)
            {
                FlowLayoutPanel Panel = new FlowLayoutPanel();
                //Panel.BorderStyle = BorderStyle.FixedSingle;
                //Panel.BackColor = Color.Red;
                Panel.Size = new System.Drawing.Size(160, 25);

                CheckBox checkBox = new CheckBox();
                checkBox.Text = stringList[i];
                checkBox.Width = 100;
                checkBox.CheckedChanged += checkedChange;
                //checkBox.CheckedChanged += Panelupdate;
                Panel.Controls.Add(checkBox);
                flowLayoutPanel.Controls.Add(Panel);
                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.Width = 40;
                numericUpDown.ValueChanged += valueChage;
                //numericUpDown.ValueChanged += Panelupdate;
                checkBox.Tag = numericUpDown;
                numericUpDown.Tag = checkBox;

                Panel.Controls.Add(numericUpDown);
            }

        }
        public static int totalByCheckbox(this FlowLayoutPanel flowLayoutPanel)
        {
            int _total = 0;
            foreach (var item in flowLayoutPanel.Controls)
            {
                FlowLayoutPanel Panel = item as FlowLayoutPanel;
                if (Panel.Controls[0] is CheckBox)
                {
                    NumericUpDown numeric = (NumericUpDown)Panel.Controls[1];
                    CheckBox checkBox = (CheckBox)Panel.Controls[0];
                    _total += checkBox.intParse() * ((int)numeric.Value);
                }
            }
            return _total;
        }

        public static List<string> returnCheckedText(this FlowLayoutPanel flowLayoutPanel)
        {
            List<string> checkedList = new List<string>();
            foreach (var item in flowLayoutPanel.Controls)
            {
                FlowLayoutPanel Panel = item as FlowLayoutPanel;
                if (Panel.Controls[0] is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)Panel.Controls[0];
                    if (checkBox.Checked)
                        checkedList.Add(checkBox.Text);
                }
            }
            return checkedList;
        }
        public static List<Item> checkItem(this FlowLayoutPanel flowLayoutPanel)
        {
            List<Item> itemList = new List<Item>();
            foreach (var item in flowLayoutPanel.Controls)
            {
                FlowLayoutPanel Panel = (item as FlowLayoutPanel);
                if (Panel.Controls[0] is CheckBox)
                {
                    NumericUpDown numericUpDown = (NumericUpDown)Panel.Controls[1];
                    CheckBox checkBox = (CheckBox)Panel.Controls[0];
                    if (checkBox.Checked && numericUpDown.Value > 0)
                    {
                        Item _item = new Item(checkBox.Text, (int)numericUpDown.Value);
                        itemList.Add(_item);
                    }
                }
            }
            return itemList;
        }
        public static int intParse(this CheckBox checkBox)
        {
            return checkBox.Checked == true ? int.Parse(checkBox.Text.Split('$')[1]) : 0;
        }

        public static void CreatByString_Width(this FlowLayoutPanel flowLayoutPanel, string str, int width)
        {
            Label label = new Label();
            label.Text = str;
            label.Width = width;
            flowLayoutPanel.Controls.Add(label);
        }


    }
}
