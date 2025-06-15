using Core.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public partial interface ICategoryRepository
    {
        public Task<List<Category>>? GetAllCategoriesByDepartmentId(int id);

        public Task<Category> GetById(int id);


    }
}
