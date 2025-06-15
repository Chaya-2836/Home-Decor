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
    public class DepartmentService : IDepartmentService
    {
        public readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<List<Department>>? GetAll()
        {
            return await _departmentRepository.GetAll();
        }
    }
}
