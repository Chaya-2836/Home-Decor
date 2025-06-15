using Core.Dao;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public List<Product> Products { get; set; }
    public List<DepartmentForCategory> departmentForCategories { get; set; }
}
