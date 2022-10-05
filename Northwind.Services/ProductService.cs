﻿using AutoMapper;
using Northwind.Contracts.Dto.Order;
using Northwind.Contracts.Dto.OrderDetail;
using Northwind.Contracts.Dto.Product;
using Northwind.Contracts.Dto.Supplier;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product = Northwind.Domain.Models.Product;

namespace Northwind.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        

        public void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, List<ProductPhotoForCreateDto> productPhotoCreateDtos)
        {
            // insert product
            var productModel = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productModel);
            _repositoryManager.Save();

            // insert photo product
            foreach (var item in productPhotoCreateDtos)
            {
                item.PhotoProductId = productModel.ProductId;
                var photoModel = _mapper.Map<ProductPhoto>(item);
                _repositoryManager.ProductPhotoRepository.Insert(photoModel);
            }
            _repositoryManager.Save();
        }

        public void Edit(ProductDto productDto)
        {
            var edit = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetAllProduct(trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        public async Task<ProductDto> GetProductById(int productId, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductById(productId, trackChanges);
            var productDto = _mapper.Map<ProductDto>(productModel);
            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProductOnSales(bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductOnSales(trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        public async Task<ProductDto> GetProductOnSalesById(int productId, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductOnSalesById(productId, trackChanges);
            var productDto = _mapper.Map<ProductDto>(productModel);
            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductPaged(pageIndex, pageSize, trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        public async Task<ProductPhotoGroupDto> GetProductPhotoById(int productId, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductPhotoRepository.GetProductPhotoById(productId, trackChanges);
            var productDto = _mapper.Map<ProductPhotoGroupDto>(productModel);
            return productDto;
        }

        public void Insert(ProductForCreateDto productForCreateDto)
        {
            var insert = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(insert);
            _repositoryManager.Save();
        }

        public void Remove(ProductDto productDto)
        {
            var remove = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Remove(remove);
            _repositoryManager.Save();
        }
        public void EditProductPhoto(ProductDto productDto, List<ProductPhotoDto> productPhotoDto)
        {
            // insert product
            var productModel = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Edit(productModel);
            _repositoryManager.Save();

            // insert photo product
            foreach (var item in productPhotoDto)
            {
                item.PhotoProductId = productModel.ProductId;
                var photoModel = _mapper.Map<ProductPhoto>(item);
                _repositoryManager.ProductPhotoRepository.Edit(photoModel);
            }
            _repositoryManager.Save();
        }
        public void CreateOrder(OrderForCreateDto orderForCreateDto, OrderDetailForCreateDto orderDetailCreateDtos)
        {
            //insert order
            var order = _mapper.Map<Order>(orderForCreateDto);
            _repositoryManager.OrderRepository.Insert(order);
            _repositoryManager.Save();

            //insert order detail
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailCreateDtos);
            orderDetail.OrderId = order.OrderId;
            _repositoryManager.OrderDetailRepository.Insert(orderDetail);
            _repositoryManager.Save();
        }
    }
}
