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
        [Required(ErrorMessage = "Please insert product name")]
        [StringLength(50,ErrorMessage = "Product name cannot be longer than 50")]
        public string ProductName { get; set; }

        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "Please insert supplier")]
        public int? SupplierId { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please insert category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Quantity PerUnit")]
        public string QuantityPerUnit { get; set; }

        [Display(Name = "Price")]
        [Required]
        [Range (10,9999999999.00)]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Units In Stock")]
        [Required]
        [Range(1, 50)]
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
