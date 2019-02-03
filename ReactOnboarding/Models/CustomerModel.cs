using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReactOnboarding.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Customer Name is Required")]
        [StringLength(20, MinimumLength = 2)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer Address is required")]
        [StringLength(70)]
        public string CustomerAddress { get; set; }

        public ICollection<ProductSold> Sales { get; set; }
    }
}