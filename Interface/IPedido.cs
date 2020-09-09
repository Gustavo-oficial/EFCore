using ORM.EFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM.EFCore.Interface
{
    interface IPedido
    {
        List<Pedido> Listar();
        Pedido BuscarPorId(Guid id);
        void Adicionar(Pedido pedido);
        void Alterar(Pedido pedido);
        void Excluir(Guid id);
    }
}
