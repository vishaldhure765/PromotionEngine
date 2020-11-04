using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PromotionApp.Models
{
    public class ProductMasterViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Prize { get; set; }
    }
}