using System.ComponentModel.DataAnnotations;

namespace ApiEstudos.Dtos;

public class PedidoDto
{
    [Required]
    public string Cliente {get; set;} = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Valor {get; set;}

    [Required]
    [RegularExpression("^(Pendente|Enviado|Cancelado)$^")]
    public string Status {get; set;} = string.Empty;
}