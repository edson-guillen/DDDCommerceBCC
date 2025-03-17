using DDDCommerceBCC.Domain;
using DDDCommerceBCC.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCommerceBCC.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly SqlContext sqlContext;

        public PedidoRepository()
        {
            sqlContext = new SqlContext();
        }

        public bool AddPedido(Pedido pedido)
        {
            if (pedido == null) return false;
            sqlContext.Pedidos.Add(pedido);
            sqlContext.SaveChanges();
            return true;
        }

        public bool DeletePedido(int id)
        {
            if (id  <= 0) return false;
            var pedido = sqlContext.Pedidos.Find(id);
            sqlContext.Pedidos.Remove(pedido);
            return true;
        }

        public List<Pedido> GetAll()
        {
            return sqlContext.Pedidos.ToList();
        }

        public Pedido GetPedidoById(int id)
        {
            return sqlContext.Pedidos.Find(id);
        }

        public void UpdatePedido(int id, Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
