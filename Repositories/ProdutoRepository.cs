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

        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto">Produto a ser adcionado</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                _ctx.Produto.Add(produto);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">Dados do produto</param>
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

        /// <summary>
        /// Busca um produto pelo seu Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
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

        /// <summary>
        /// Busca produto pelo nome
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <returns>Retorna um produto</returns>

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

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do Produto</param>

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

        /// <summary>
        /// Lista todos os produto
        /// </summary>
        /// <returns>Lista de Produtos</returns>
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
