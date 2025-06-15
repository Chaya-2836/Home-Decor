using Core.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface IProductInStockRepository
    {
        public Task<int> decreaseStock(int productInStockId, int sum);
        public Task<List<ProductInStock>> getByCategoryId(int categoryId);
        Task<List<ProductInStock>> GetFilteredAsync(
            int categoryId,
            double? minPrice,
            double? maxPrice,
            List<productTypes>? types);

        public Task<ProductInStock> getById(int Id);


    }
}
