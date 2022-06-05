using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepo : Repository<Order>, IOrderRepo
    {
        public OrderRepo(OrderContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByCountry(string country)
        {
            var orderList = await _db.Orders
                .Where(o => o.Country == country)
                .ToListAsync();
            return orderList;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _db.Orders
                .Where(o => o.UserName == userName)
                .ToListAsync();
            return orderList;
        }
    }
}
