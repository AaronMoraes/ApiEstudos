using System.Data.Common;
using System.Net;
using ApiEstudos.Dtos;
using ApiEstudos.Models;

namespace ApiEstudos.Mappers;

public static class PedidoMapper
{
    public static PedidoResponseDto ToResponseDto(Pedido pedido)
    {
        return new PedidoResponseDto
        {
            Id = pedido.Id,
            Cliente = pedido.Cliente,
            Valor = pedido.Valor,
            Status = pedido.Status
        };
    }
}