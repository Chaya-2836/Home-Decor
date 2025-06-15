using Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataRepository
{

    public class OrderRepository : IOrderRepository
    {

        private readonly ProjectContext _dbContext;
        public OrderRepository(ProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Core.Dao.Order> addOrderAsync(Core.Dao.Order newOrder)
        {
            try
            {
                await _dbContext.Orders.AddAsync(newOrder);
                int x = await _dbContext.SaveChangesAsync();
                if (x > 0)
                    return newOrder;
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
