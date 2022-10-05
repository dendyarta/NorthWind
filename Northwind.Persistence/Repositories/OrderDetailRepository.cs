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
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }


        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetail(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(x => x.ProductId)
                .Include(p => p.Product)
                .ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int orderId, bool trackChanges)
        {
            return await FindByCondition(x => x.ProductId.Equals(orderId), trackChanges)
                .Include(p => p.Product)
                .SingleOrDefaultAsync();
        }

        public void Insert(OrderDetail OrderDetail)
        {
            throw new NotImplementedException();
        }

        public void Edit(OrderDetail OrderDetail)
        {
            throw new NotImplementedException();
        }

        public void Remove(OrderDetail OrderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
