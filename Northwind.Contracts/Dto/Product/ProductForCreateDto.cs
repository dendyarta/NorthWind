using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.Product
{
    public class ProductForCreateDto
    {
        [Display(Name = "Product Name")]
        [Required]
        [StringLength(50,ErrorMessage = "Product name cannot be longer than 50")]
        public string ProductName { get; set; }

        [Display(Name = "Supplier Id")]
        public int? SupplierId { get; set; }

        [Display(Name = "Category Id")]
        public int? CategoryId { get; set; }

        [Display(Name = "Quantity PerUnit")]
        public string QuantityPerUnit { get; set; }

        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Units In Stock")]
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
