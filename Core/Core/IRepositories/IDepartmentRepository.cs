using Core.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public partial interface IDepartmentRepository
    {
        Task<List<Department>>? GetAll();
    }
}
