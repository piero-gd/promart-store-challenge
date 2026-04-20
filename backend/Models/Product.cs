namespace PromartStore.API.Models;

public class ProductRating
{
    public int Id { get; set; }
    public double Rate { get; set; }
    public int Count { get; set; }
    public int ProductId { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public List<string> Images { get; set; } = new();
    public string Specifications { get; set; } = string.Empty;
    public ProductRating Rating { get; set; } = new();
}
