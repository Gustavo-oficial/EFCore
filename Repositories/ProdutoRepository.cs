using ORM.EFCore.Domains;
using ORM.EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM.EFCore.Repositories
{
    public class ProdutoRepository : IProduto
    {
        private readonly PedidoContext _ctx;

            public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        public void Adicionar(Produto produto)
        {
            try
            {
                _ctx.Produto.Add(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Produto produto)
        {
            try
            {
                Produto produtotemp = BuscarPorId(produto.Id);

                if (produto == null)
                    throw new Exception("Pedido não encontrado");

                produtotemp.Nome = produto.Nome;
                produtotemp.Preco = produto.Preco;

                _ctx.Produto.Update(produtotemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Produto.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                List<Produto> produto = _ctx.Produto.Where(c => c.Nome.Contains(nome)).ToList();
                    return produto;
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
                Produto produto = BuscarPorId(id);

                if (produto == null)
                    throw new Exception("Produto não encontrado");

                _ctx.Produto.Remove(produto);
                _ctx.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produto.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
