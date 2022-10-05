﻿using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetail(bool trackChanges);

        Task<OrderDetail> GetOrderDetailById(int orderId, bool trackChanges);

        void Insert(OrderDetail OrderDetail);

        void Edit(OrderDetail OrderDetail);

        void Remove(OrderDetail OrderDetail);
    }
}
