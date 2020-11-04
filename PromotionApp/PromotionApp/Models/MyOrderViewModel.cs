using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromotionApp.Models
{
    public class MyOrderViewModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Prize { get; set; }
        public int Quantity { get; set; }
        public decimal ItemTotal { get; set; }
    }
}