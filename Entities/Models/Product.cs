using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("products")]
    public class Product
    {
        public int ProductID { get; set; }         
        [Required(ErrorMessage ="Product Name is required")]
        [StringLength(40,ErrorMessage = "Product Name can't be longer than 40 characters")]
        public string ProductName { get; set; }       
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
