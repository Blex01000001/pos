using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pos.Models.MenuModel;

namespace pos.Models
{
    public class KeyValueModel
    {
        public String Key { get; set; }
        public DiscountStrategy Value { get; set; }
        public KeyValueModel(String Key, DiscountStrategy discountStrategy)
        {
            this.Key = Key;
            this.Value = discountStrategy;
        }
    }
}
