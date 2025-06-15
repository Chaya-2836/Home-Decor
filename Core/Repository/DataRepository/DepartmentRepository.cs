using Core.Dao;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ProjectContext _projectContext;

        public DepartmentRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        public async Task<List<Department>>? GetAll()
        {
            return await _projectContext.Departments.ToListAsync();
        }
    }
}
