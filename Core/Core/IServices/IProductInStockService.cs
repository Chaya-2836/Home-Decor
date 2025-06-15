using Core.Dao;
using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IProductInStockService
    {
        public Task<int> decreaseStock(int productInStockId, int sum);
        public Task<List<ProductInStock>> getByCategoryId(int categoryId);
        Task<List<ProductInStockDto>> GetFilteredAsync(
            int categoryId,
            double? minPrice,
            double? maxPrice,
            List<productTypes>? types);
        public Task<ProductInStock> getById(int Id);

    }
}
