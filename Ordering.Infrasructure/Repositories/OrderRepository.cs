using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;
using Ordering.Infrasructure.Data;
using Ordering.Infrasructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrasructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext _dbContext) : base(_dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersBySellerUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                    .Where(x => x.SellerUserName == userName).ToListAsync();
            return orderList;
        }
    }
}
