using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dao
{
    public class DepartmentForCategory
    {
        public int Id { get; set; }

        public Category Category { get; set; } 

        public Department Department { get; set; }
    }
}
