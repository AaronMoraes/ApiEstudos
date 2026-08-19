using ApiEstudos.Services;
using ApiEstudos.Models;
using ApiEstudos.Dtos;
using ApiEstudos.Mappers;
using Microsoft.AspNetCore.Mvc;


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

        return PedidoMapper.ToResponseDto(pedido);
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

        var response = PedidoMapper.ToResponseDto(novoPedido);

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


        var response = PedidoMapper.ToResponseDto(pedidoAtualizado);

        return response;
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _pedidoService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
    
