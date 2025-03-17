using DDDCommerceBCC.Domain;
using DDDCommerceBCC.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DDDCommerceBCC.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly SqlContext _sqlContext;

        public PedidoRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public void AddPedido(Pedido pedido)
        {
            _sqlContext.Pedidos.Add(pedido);
            _sqlContext.SaveChanges();
        }

        public void DeletePedido(int id)
        {
            var pedido = _sqlContext.Pedidos.Find(id);
            if (pedido != null)
            {
                _sqlContext.Pedidos.Remove(pedido);
                _sqlContext.SaveChanges();
            }
        }

        public IEnumerable<Pedido> GetAllPedidos()
        {
            return _sqlContext.Pedidos.ToList();
        }

        public Pedido GetPedidoById(int id)
        {
            return _sqlContext.Pedidos.Find(id);
        }

        public void UpdatePedido(int id, Pedido pedido)
        {
            var existingPedido = _sqlContext.Pedidos.Find(id);
            if (existingPedido != null)
            {
                existingPedido.Data = pedido.Data;
                existingPedido.LojaOrigem = pedido.LojaOrigem;
                _sqlContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Pedido not found");
            }
        }
    }
}
