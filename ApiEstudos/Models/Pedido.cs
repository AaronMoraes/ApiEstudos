namespace ApiEstudos.Models;

public class Pedido
{
    public int Id { get; set; }

    public string Cliente { get; set; } = string.Empty;

    public decimal Valor { get; set; } 

    public string Status { get; set; } = string.Empty;
}