using ApiEstudos.Models;
using ApiEstudos.Services;
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
    public ActionResult <Pedido> GetById(int id)
    {
        var pedido = _pedidoService.GetById(id);

        if (pedido == null)
        {
            return NotFound();
        }
        
        return pedido;
    }
    [HttpPost]
    public ActionResult<Pedido> Post(Pedido pedido)
    {
        var novoPedido = _pedidoService.Create(pedido);

        return CreatedAtAction(
            nameof(GetById),
            new {id = novoPedido.Id},
            novoPedido
        );
    }
    [HttpPut("{id}")]
    public ActionResult<Pedido> Put(int id, Pedido pedido)
    {
        var pedidoAtualizado = _pedidoService.Update(id, pedido);

        if (pedidoAtualizado == null)
        {
            return NotFound();
        }

        return Ok(pedidoAtualizado);
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
    
