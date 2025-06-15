using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IOrderService
    {
        public Task<Core.Dao.Order> addOrderAsync(Core.Dao.Order newOrder);
    }
}
