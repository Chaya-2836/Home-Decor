using Core;
using Core.Dao;
using Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataRepository
{
    public class ProductInStockRepository : IProductInStockRepository
    {
        private readonly ProjectContext _dbContext;
        public ProductInStockRepository(ProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> decreaseStock(int productInStockId, int sum)
        {
            try
            {
                ProductInStock p = await _dbContext.ProductInStock.SingleOrDefaultAsync(p => p.Product.SKU == productInStockId);
                if (p.Quantity - sum < 0)
                    throw new Exception("Not enough in stock");
                p.Quantity -= sum;
                _dbContext.ProductInStock.Update(p);
                int x = await _dbContext.SaveChangesAsync();
                if (x > 0)
                    return p.Quantity;
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<ProductInStock>> getByCategoryId(int categoryId)
        {
            return await _dbContext.ProductInStock
                .Include(p => p.Product)
                .Where(p => _dbContext.Categories
                    .Where(c => c.Id == categoryId)
                    .SelectMany(c => c.Products)
                    .Any(prod => prod.SKU == p.Product.SKU))
                .ToListAsync();
        }
        public async Task<List<ProductInStock>> GetFilteredAsync(
     int categoryId,
     double? minPrice,
     double? maxPrice,
     List<productTypes>? types)
        {
            var query = _dbContext.ProductInStock
                .Include(p => p.Product)
                .Where(p => p.Product.CategoryId == categoryId);

            if (minPrice.HasValue)
                query = query.Where(p => p.Product.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Product.Price <= maxPrice.Value);

            if (types != null && types.Any())
                query = query.Where(p => types.Any(t => (p.Product.Type & t) == t));

            return await query.ToListAsync();
        }

        public async Task<ProductInStock> getById(int Id)
        {
            return await _dbContext.ProductInStock
    .Include(x => x.Product)
    .Where(x => x.Id == Id)
    .FirstOrDefaultAsync();

        }

    }
}
