using Core.Dao;
using Core;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int SKU { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public productTypes Type { get; set; }

    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}
