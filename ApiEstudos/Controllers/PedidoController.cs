using ApiEstudos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstudos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private static readonly List<Pedido> Pedidos = new()
    {
        new Pedido
        {
            Id = 1,
            Cliente = "Cliente 1",
            Valor = 150.50m,
            Status = "Pendente"
        },
        new Pedido
        {
            Id = 2,
            Cliente = "Cliente 2",
            Valor = 320.00m,
            Status = "Enviado"
        }
    };

    [HttpGet]
    public IEnumerable <Pedido> Get()
    {
        return Pedidos;
    }
    [HttpGet("{id}")]
    public ActionResult <Pedido> GetById(int id)
    {
        var pedido = Pedidos.FirstOrDefault(p => p.Id == id);

        if (pedido == null)
        {
            return NotFound();
        }
        
        return pedido;
    }
    [HttpPost]
    public ActionResult<Pedido> Post(Pedido pedido)
    {
        pedido.Id = Pedidos.Max(p => p.Id) + 1;

        Pedidos.Add(pedido);

        return CreatedAtAction(nameof(GetById), new {id = pedido.Id}, pedido);
    }
    [HttpPut("{id}")]
    public ActionResult<Pedido> Put(int id, Pedido pedido)
    {
        var pedidoExistente = Pedidos.FirstOrDefault(p => p.Id == id);

        if (pedidoExistente == null)
        {
            return NotFound();
        }

        pedidoExistente.Cliente = pedido.Cliente;
        pedidoExistente.Valor = pedido.Valor;
        pedidoExistente.Status = pedido.Status;

        return Ok(pedidoExistente);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pedido = Pedidos.FirstOrDefault(p => p.Id == id);

        if (pedido == null)
        {
            return NotFound();
        }

        Pedidos.Remove(pedido);

        return NoContent();
    }
}
    
