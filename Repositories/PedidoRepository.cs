using Microsoft.EntityFrameworkCore;
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
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }
        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                //Crio um objeto do tipo pedido
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now,
                    PedidosItens = new List<PedidoItem>()
                };

                //Adiciono itens ao meu pedidoItens
                foreach (var item in pedidosItens)
                {
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id,
                        IdProduto = item.IdProduto, 
                        Quantidade = item.Quantidade 
                    });
                }

                _ctx.Pedido.Add(pedido);
                _ctx.SaveChanges();

                return pedido;
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedido
                        .Include(i => i.PedidosItens)
                        .ThenInclude(x => x.Produto)
                        .ToList();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
