using System.Text.Json.Serialization;
namespace ApI2.Model;
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public ICollection<Book>? Books { get; set; }
}
