using System;
using System.Collections.Generic;
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

        public static void createCheckboxByString(this FlowLayoutPanel flowLayoutPanel, string[] stringList)
        {
            for (int i = 0; i < stringList.Length; i++)
            {
                Label label33 = new Label();
                CheckBox checkBox = new CheckBox();
                checkBox.Text = stringList[i];
                checkBox.Width = 200;
                flowLayoutPanel.Controls.Add(checkBox);
            }
        }
        public static int totalByCheckbox(this FlowLayoutPanel flowLayoutPanel)
        {
            int _total = 0;
            foreach (var item in flowLayoutPanel.Controls)
            {
                if (item is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)item;
                    _total += checkBox.intParse();
                }
            }
            return _total;
        }

        public static List<string> returnCheckedText(this FlowLayoutPanel flowLayoutPanel)
        {
            List<string> checkedList = new List<string>();
            foreach (var item in flowLayoutPanel.Controls)
            {
                if (item is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)item;
                    if (checkBox.Checked)
                        checkedList.Add(checkBox.Text);
                }
            }
            return checkedList;
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
