using DDDCommerceBCC.Domain;
using System.Collections.Generic;

namespace DDDCommerceBCC.Infra.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido GetPedidoById(int id);
        IEnumerable<Pedido> GetAllPedidos();
        void AddPedido(Pedido pedido);
        void UpdatePedido(int id, Pedido pedido);
        void DeletePedido(int id);
    }
}
