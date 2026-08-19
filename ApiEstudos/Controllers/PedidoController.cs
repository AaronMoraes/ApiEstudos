using ApiEstudos.Models;
using ApiEstudos.Services;
using ApiEstudos.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Net;

namespace ApiEstudos.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly PedidoService _pedidoService;
    public PedidoController (PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }


    [HttpGet]
    public IEnumerable <Pedido> Get()
    {
        return _pedidoService.GetAll();
    }
    [HttpGet("{id}")]
    public ActionResult<PedidoResponseDto> GetById(int id)
    {
        var pedido = _pedidoService.GetById(id);

        if (pedido == null)
        {
            return NotFound();
        }

        var response = new PedidoResponseDto
        {
            Id = pedido.Id,
            Cliente = pedido.Cliente,
            Valor = pedido.Valor,
            Status = pedido.Status
        };

        return response;
    }
    [HttpPost]
    public ActionResult<PedidoResponseDto> Post(PedidoDto pedidoDto)
    {
        var pedido = new Pedido
        {
            Cliente = pedidoDto.Cliente,
            Valor = pedidoDto.Valor,
            Status = pedidoDto.Status
        };

        var novoPedido = _pedidoService.Create(pedido);

        var response = new PedidoResponseDto
        {
            Id = novoPedido.Id,
            Cliente = novoPedido.Cliente,
            Valor = novoPedido.Valor,
            Status = novoPedido.Status
        };

        return CreatedAtAction(
            nameof(GetById),
            new { id = novoPedido.Id },
            response
        );
        
    }
    [HttpPut("{id}")]
    public ActionResult<PedidoResponseDto> Put(int id, PedidoDto pedidoDto)
    {
        var pedido = new Pedido
        {
            Cliente = pedidoDto.Cliente,
            Valor = pedidoDto.Valor,
            Status = pedidoDto.Status
        };

        var pedidoAtualizado = _pedidoService.Update(id, pedido);

        if(pedidoAtualizado == null)
        {
            return NotFound();
        }

        var response = new PedidoResponseDto
        {
            Id = pedidoAtualizado.Id,
            Cliente = pedidoAtualizado.Cliente,
            Valor = pedidoAtualizado.Valor,
            Status = pedidoAtualizado.Status
        };

        return response;
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var removido = _pedidoService.Delete(id);

        if(!removido)
        {
            return NotFound();
        }

        return NoContent();
    }
}
    
