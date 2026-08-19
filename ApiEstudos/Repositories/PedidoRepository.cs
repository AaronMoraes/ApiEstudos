using ApiEstudos.Models;

namespace ApiEstudos.Repositories;

public class PedidoRepository : IPedidoRepository
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

    public IEnumerable<Pedido> GetAll()
    {
        return Pedidos;
    }

    public Pedido? GetById (int id)
    {
        return Pedidos.FirstOrDefault(p => p.Id == id);
    }

    public Pedido Create(Pedido pedido)
    {
        pedido.Id = Pedidos.Max(p => p.Id) + 1;

        Pedidos.Add(pedido);

        return pedido;
    }

    public Pedido? Update(int id, Pedido pedido)
    {
        var pedidoExistente = Pedidos.FirstOrDefault(p => p.Id == id);

        if(pedidoExistente == null)
        {
            return null;
        }

        pedidoExistente.Cliente = pedido.Cliente;
        pedidoExistente.Valor = pedido.Valor;
        pedidoExistente.Status = pedido.Status;


        return pedidoExistente;
    }

    public bool Delete(int id)
    {
        var pedido = Pedidos.FirstOrDefault(p => p.Id == id);

        if (pedido == null)
        {
            return false;
        }

        Pedidos.Remove(pedido);

        return true;
    }

}
