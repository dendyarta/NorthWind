using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.Product
{
    public class ProductPhotoGroupDto
    {
        public ProductForCreateDto ProductForCreateDto { get; set; }
        public ProductDto ProductDto { get; set; }

        public ProductPhotoDto ProductPhotoDto { get; set; }

        [Required(ErrorMessage = "Please Insert Photo")]
        public List<IFormFile> AllPhoto { get; set; }
    }
}
