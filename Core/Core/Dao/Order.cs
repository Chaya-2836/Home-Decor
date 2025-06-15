using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dao
{
    public class Order
    {
        public int id {  get; set; }
        public List<ProductOrdered> ordered { get; set; }
        
    }
}
