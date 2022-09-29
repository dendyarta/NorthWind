using Microsoft.EntityFrameworkCore;
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
    public class ProductPhotoRepository : RepositoryBase<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        
        public async Task<IEnumerable<ProductPhoto>> GetAllProductPhoto(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(p => p.PhotoId)
                .Include(c => c.PhotoProduct)
                .ToListAsync();
        }

        public async Task<ProductPhoto> GetProductPhotoById(int photoId, bool trackChanges)
        {
            return await FindByCondition(p => p.PhotoId.Equals(photoId), trackChanges)
                .OrderBy(p => p.PhotoId)
                .Include(c => c.PhotoProduct)
                .SingleOrDefaultAsync();
            
                //.Include(s => s.Supplier)
        }

        /*public async Task<IEnumerable<Product>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(p => p.ProductId)
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .Skip((pageIndex - 1 ) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }*/

        public void Insert(ProductPhoto productPhoto)
        {
            Create(productPhoto);
        }

        public void Edit(ProductPhoto productPhoto)
        {
            Update(productPhoto);
        }


        public void Remove(ProductPhoto productPhoto)
        {
            Delete(productPhoto);
        }
    }
}
