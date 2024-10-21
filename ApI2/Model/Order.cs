using System.Text.Json.Serialization;
namespace ApI2.Model;
public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    [JsonIgnore]
    public string Status { get; set; } = "Javob yo'q";
    [JsonIgnore]
    public ICollection<OrderBook>? OrderBooks { get; set; }
}
