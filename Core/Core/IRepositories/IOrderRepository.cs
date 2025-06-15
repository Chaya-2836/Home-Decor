using Core.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface IOrderRepository
    {
        public Task<Core.Dao.Order> addOrderAsync(Core.Dao.Order newOrder);

    }
}
