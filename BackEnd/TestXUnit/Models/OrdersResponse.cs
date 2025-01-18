namespace TestXUnit.Models;

public class OrdersResponse
{
    public int id { get; set; }
    public DateTime? fechaRequerida { get; set; }
    public DateTime? fechaCompra { get; set; }
    public string? nombre { get; set; }
    public string? direccion { get; set; }
    public string? ciudad { get; set; }
}
