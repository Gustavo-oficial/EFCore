using ORM.EFCore.Domains;
using System;
using System.Collections.Generic;


namespace ORM.EFCore.Interface
{
    public interface IProduto
    {
        List<Produto> Listar();
        List<Produto> BuscarPorNome(string nome);
        Produto BuscarPorId(Guid id);
        void Adicionar(Produto produto);
        void Alterar(Produto produto);
        void Excluir(Guid id);
    }
}
