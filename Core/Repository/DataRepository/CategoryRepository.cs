using Core.Dao;
using Core.Dto;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProjectContext _projectContext;
        public CategoryRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<List<Category>>? GetAllCategoriesByDepartmentId(int id)
        {
            return await _projectContext.Categories.Where(x => x.departmentForCategories.Any(d=>d.Department.Id== id)).ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _projectContext.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
