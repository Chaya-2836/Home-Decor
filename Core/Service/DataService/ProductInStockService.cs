using AutoMapper;
using Core;
using Core.Dao;
using Core.Dto;
using Core.IRepositories;
using Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataService
{
    public class ProductInStockService : IProductInStockService
    {
        private readonly IProductInStockRepository _productInStockRepository;
        private readonly IMapper _mapper;

        public ProductInStockService(IProductInStockRepository productInStockRepository, IMapper mapper)
        {
            _productInStockRepository = productInStockRepository;
            _mapper = mapper;
        }

        public async Task<int> decreaseStock(int productInStockId, int sum)
        {
            try
            {
                return await _productInStockRepository.decreaseStock(productInStockId, sum);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ProductInStock>> getByCategoryId(int id)
        {
            try
            {
                return await _productInStockRepository.getByCategoryId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ProductInStockDto>> GetFilteredAsync(
       int categoryId,
       double? minPrice,
       double? maxPrice,
       List<productTypes>? types)
        {
            var result = await _productInStockRepository.GetFilteredAsync(categoryId, minPrice, maxPrice, types);
            return _mapper.Map<List<ProductInStockDto>>(result);
        }
        public async Task<ProductInStock> getById(int Id)
        {
            return await _productInStockRepository.getById(Id);
        }
    }
}
