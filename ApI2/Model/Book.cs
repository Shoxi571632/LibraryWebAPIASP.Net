namespace ApI2.Model;
public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfOrders { get; set; }
    public int CategoryId { get; set; }
    public int amount { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public Category? Category { get; set; }
    public ICollection<OrderBook>? OrderBooks { get; set; }
}
