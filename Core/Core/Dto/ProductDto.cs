using Core;

public class ProductDto
{
    public int SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public productTypes Type { get; set; }
    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }
}
