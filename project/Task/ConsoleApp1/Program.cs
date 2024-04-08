using System.Text.Json;
using System.Text.Json.Serialization;

public class Order
{
    public int OrderId
    {
        get; set; }
    [JsonIgnore]
public double Total { get; set;  }
    }
class Program
{
    static void Main(string[] args)
    {
        string orderjson = @"[{""OrderId"":1,""Total"":10.5},{""OrderID"":2,""Total"":20.5}]";
        var orders = JsonSerializer.Deserialize<List<Order>>(orderjson);
        Console.WriteLine($"{orders.Count}:{orders.Sum(o=>o.Total)}");
        Console.ReadKey();
    }
}
    