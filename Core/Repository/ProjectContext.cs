using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dao;

namespace Repository
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options):base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentForCategory> DepartmentForCategories { get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInStock> ProductInStock { get; set; }
        public DbSet<ProductOrdered> ProductOrdereds { get; set; }
        public DbSet<Order> Orders { get; set; }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//=> optionsBuilder.UseSqlServer("Server=חיהלה-055676283;Database=HomeAccessories;Trusted_Connection=True;TrustServerCertificate=True");
    }


}
