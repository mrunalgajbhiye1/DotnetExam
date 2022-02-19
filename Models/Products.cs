using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetAnswer.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please enter Product name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter proper rate")]
        public decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter proper Description")]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter proper Category")]
        public string CategoryName { get; set; }
    
    
    }
}