using Northwind.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Base
{
    public interface IRepositoryManager
    {
        ICategoryRepository CategoryRepository { get; }
        ICustomerRepository EmployeeRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductPhotoRepository ProductPhotoRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }

        void Save();

        Task SaveAsync();
    }
}
