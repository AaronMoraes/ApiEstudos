namespace ApiEstudos.Dtos;

public class PedidoResponseDto
{
    public int Id {get; set;}
    public string Cliente {get; set;} = string.Empty;
    public decimal Valor {get; set;}
    public string Status {get; set;} = string.Empty;
}