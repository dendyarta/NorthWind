using Northwind.Contracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    internal interface IProductPhotoGroupService
    {
        Task<IEnumerable<ProductPhotoDto>> GetAllProductPhoto(bool trackChanges);
        Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges);
    }
}
