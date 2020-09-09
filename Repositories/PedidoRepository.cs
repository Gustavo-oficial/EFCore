using ORM.EFCore.Domains;
using ORM.EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM.EFCore.Repositories
{
    public class PedidoRepository : IPedido
    {
        private readonly PedidoContext ctx;

        public PedidoRepository()
        {
            ctx = new PedidoContext();
        }
        public void Adicionar(Pedido pedido)
        {
            try
            {
                ctx.Pedido.Add(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Pedido pedido)
        {
            try
            {
                Pedido pedidotem = BuscarPorId(pedido.Id);

                if (pedido == null)
                    throw new Exception("Pedido não encontrado");

                pedidotem.Status = pedido.Status;
                pedidotem.OrderDate = pedido.OrderDate;

                ctx.Pedido.Update(pedidotem);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Pedido.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                Pedido pedido = BuscarPorId(id);

                if (pedido == null)
                    throw new Exception("Pedido não encontrado");

      

                ctx.Pedido.Remove(pedido);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return ctx.Pedido.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
