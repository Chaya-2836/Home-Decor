using Core.Dao;
using Core.IRepository;
using Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataService
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<Category>>? GetAllCategoriesByDepartmentId(int id)
        {
            return await _categoryRepository.GetAllCategoriesByDepartmentId(id);
        }


        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }
    }
}
