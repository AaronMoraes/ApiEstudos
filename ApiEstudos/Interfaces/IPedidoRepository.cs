using ApiEstudos.Models;

namespace ApiEstudos.Interfaces;

public interface IPedidoRepository
{
    IEnumerable<Pedido> GetAll();

    Pedido? GetById(int id);

    Pedido Create(Pedido pedido);

    Pedido? Update(int id, Pedido pedido);

    bool Delete(int id);
}