using Microsoft.AspNetCore.Mvc;
using ORM.EFCore.Domains;
using ORM.EFCore.Interface;
using ORM.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IPedido _pedidoRepository;

        public PedidoController()
        {
            _pedidoRepository = new PedidoRepository();
        }

        [HttpGet]
        public List<Pedido> Get()
        {
            return _pedidoRepository.Listar();
        }

        [HttpGet("{id}")]
        public Pedido Get(Guid id)
        {
            return _pedidoRepository.BuscarPorId(id);
        }

        [HttpPost]
        public void Post(Pedido pedido)
        {
            _pedidoRepository.Adicionar(pedido);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, Pedido pedido)
        {
            pedido.Id = id;
            _pedidoRepository.Alterar(pedido);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _pedidoRepository.Excluir(id);
        }
    }
}
