namespace RakhraSoft.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public double? Price { get; set; }
    public List<ProductProp> ProductProperties { get; set; }
}

