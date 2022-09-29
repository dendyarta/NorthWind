using AutoMapper;
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
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductPhotoService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(ProductPhotoDto productPhotoDto)
        {
            var edit = _mapper.Map<ProductPhoto>(productPhotoDto);
            _repositoryManager.ProductPhotoRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<ProductPhotoDto>> GetAllProductPhoto(bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductPhotoRepository.GetAllProductPhoto(trackChanges);
            var productPhotoDto = _mapper.Map<IEnumerable<ProductPhotoDto>>(productModel);
            return productPhotoDto;
        }

        public async Task<ProductPhotoDto> GetProductPhotoById(int productId, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductPhotoRepository.GetProductPhotoById(productId, trackChanges);
            var productDto = _mapper.Map<ProductPhotoDto>(productModel);
            return productDto;
        }

        /*public async Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            var productModel = await _repositoryManager
                .ProductRepository.GetProductPaged(pageIndex,pageSize,trackChanges);

            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }*/

        public void Insert(ProductPhotoForCreateDto productPhotoForCreateDto)
        {
            var insert = _mapper.Map<ProductPhoto>(productPhotoForCreateDto);
            _repositoryManager.ProductPhotoRepository.Insert(insert);
            _repositoryManager.Save();
        }

        public void Remove(ProductPhotoDto productPhotoDto)
        {
            var remove = _mapper.Map<ProductPhoto>(productPhotoDto);
            _repositoryManager.ProductPhotoRepository.Remove(remove);
            _repositoryManager.Save();
        }
    }
}
