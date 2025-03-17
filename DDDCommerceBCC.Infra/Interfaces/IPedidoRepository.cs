using DDDCommerceBCC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCommerceBCC.Infra.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido GetPedidoById(int id);
        bool AddPedido(Pedido pedido);
        List<Pedido> GetAll();
        void UpdatePedido(int id, Pedido pedido); 
        bool DeletePedido(int id);
    }
}
