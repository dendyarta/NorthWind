﻿using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Order;
using Northwind.Contracts.Dto.OrderDetail;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges);

        Task<ProductDto> GetProductById(int productId, bool trackChanges);
        Task<ProductDto> GetProductOnSalesById(int productId, bool trackChanges);

        Task<ProductPhotoGroupDto> GetProductPhotoById(int productId, bool trackChanges);

        Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges);

        Task<IEnumerable<ProductDto>> GetProductOnSales(bool trackChanges);

        void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, List<ProductPhotoForCreateDto> productPhotoCreateDtos);

        void Insert(ProductForCreateDto productForCreateDto);

        void Edit(ProductDto productDto);

        void Remove(ProductDto productDto);

        void CreateOrder(OrderForCreateDto orderForCreateDto, OrderDetailForCreateDto orderDetailCreateDtos);

        void EditProductPhoto(ProductDto productDto, List<ProductPhotoDto> productPhotoDto);

    }
}
