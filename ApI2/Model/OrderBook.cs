using System.Text.Json.Serialization;
namespace ApI2.Model;
public class OrderBook
{
    public int OrderId { get; set; }
    [JsonIgnore]
    public Order? Order { get; set; }

    public int BookId { get; set; }
    [JsonIgnore]
    public Book? Book { get; set; }
}
