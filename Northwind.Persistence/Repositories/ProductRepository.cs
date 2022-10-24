using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Dto;
using Northwind.Domain.Models;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProduct(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(p => p.ProductId)
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .ToListAsync();
        }


        public async Task<Product> GetProductById(int productId, bool trackChanges)
        {
            return await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .Include(x => x.ProductPhotos)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductOnSales(bool trackChanges)
        {
            /*select * from products p 
             * where exists(select * from ProductPhotos pp 
             * where pp.PhotoProductId = p.ProductID)*/

            // diatas query SQL dibawah query by c#

            var product = await FindAll(trackChanges)
                .Where(x => x.ProductPhotos.Any(y => y.PhotoProductId == x.ProductId))
                .Include(p => p.ProductPhotos)
                .ToListAsync();
            return product;
        }

        public async Task<Product> GetProductOnSalesById(int productId, bool trackChanges)
        {
            var products = await FindByCondition(x => x.ProductId.Equals(productId), trackChanges)
                .Where(y => y.ProductPhotos.Any(p => p.PhotoProductId == productId))
                .Include(a => a.ProductPhotos)
                .SingleOrDefaultAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(p => p.ProductId)
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public void Insert(Product product)
        {
            Create(product);
        }
        public void Edit(Product product)
        {
            Update(product);
        }
        public void Remove(Product product)
        {
            Delete(product);
        }

        public IEnumerable<TotalProductByCategory> GetTotalProductByCategory(bool trackChanges)
        {
            var rawSQL = _dbContext.TotalProductByCategorySQL
                .FromSqlRaw("select c.CategoryName, count(p.productId) TotalProduct from products p join Categories c on p.CategoryID=c.CategoryID group by c.CategoryName")
                .Select(x => new TotalProductByCategory
                {
                    CategoryName = x.CategoryName,
                    TotalProduct = x.TotalProduct
                })
                .OrderBy(x => x.TotalProduct)
                .ToList();
            return rawSQL;
        }
    }
}
