using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos
{
    public class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Qt { get; set; }
        //public bool Check{ get; set; }
        public int Subtotal { get; set; }


        public Item(string checkboxText, decimal _Qt)
        {
            this.Name = checkboxText.Split('$')[0];
            this.Price = int.Parse(checkboxText.Split('$')[1]);
            this.Qt = (int)_Qt;
            this.Subtotal = Price * Qt;
        }

    }
}
