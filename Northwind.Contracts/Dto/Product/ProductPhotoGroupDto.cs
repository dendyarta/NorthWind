﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.Product
{
    public class ProductPhotoGroupDto
    {
        public ProductForCreateDto ProductForCreateDto { get; set; } 
        public IFormFile Photo1 { get; set; }
        public IFormFile Photo2 { get; set; }
        public IFormFile Photo3 { get; set; }
    }
}
