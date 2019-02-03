using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReactOnboarding.Models
{
    public class StoreModel
    {
        [Key]
        public int StoreId { get; set; }

        [DisplayName("Store Name")]
        [Required(ErrorMessage = "Store Name is required")]
        [StringLength(20, MinimumLength = 3)]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "Store Address is required")]
        [StringLength(70)]
        public string StoreAddress { get; set; }

        public ICollection<ProductSold> Sales { get; set; }
    }
}