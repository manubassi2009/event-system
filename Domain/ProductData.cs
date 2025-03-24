namespace Domain;

public class ProductData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public bool IsDiscounted { get; set; }
    public string Category { get; set; }
}
