using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface IProductPhotoService
    {
        Task<IEnumerable<ProductPhotoDto>> GetAllProductPhoto(bool trackChanges);

        Task<ProductPhotoDto> GetProductPhotoById(int photoId, bool trackChanges);

        //Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges);

        void Insert(ProductPhotoForCreateDto productPhotoForCreateDto);

        void Edit(ProductPhotoDto productPhotoDto);

        void Remove(ProductPhotoDto productPhotoDto);
    }
}
