using ApiEstudos.Repositories;
using ApiEstudos.Models;

namespace ApiEstudos.Services;

public class PedidoService
{
    private readonly PedidoRepository _pedidoRepository;

    public PedidoService(PedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }


    public Pedido? GetById(int id)
    {
        return _pedidoRepository.GetById(id);
    }
    
    public IEnumerable<Pedido> GetAll()
    {
        return _pedidoRepository.GetAll();
    }
    
    public Pedido Create(Pedido pedido)
    {
        return _pedidoRepository.Create(pedido);
    }
    public Pedido? Update(int id, Pedido pedido)
    {
        return _pedidoRepository.Update(id, pedido);
    }

    public bool Delete(int id)
    {
        return _pedidoRepository.Delete(id);
    }
}