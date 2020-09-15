using ORM.EFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM.EFCore.Interface
{
    public interface IPedido
    {
        List<Pedido> Listar();
        Pedido Adicionar(List<PedidoItem> pedidosItens);
    }
}
