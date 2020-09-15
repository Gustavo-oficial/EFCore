using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM.EFCore.Domains;
using ORM.EFCore.Interface;
using ORM.EFCore.Repositories;

namespace ORM.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedido _pedidoRepository;

        public PedidoController()
        {
            _pedidoRepository = new PedidoRepository();
        }

        [HttpPost]
        public IActionResult Post(List<PedidoItem> pedidosItens)
        {
            try
            {
                Pedido pedido = _pedidoRepository.Adicionar(pedidosItens);

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pedidos = _pedidoRepository.Listar();

                if (pedidos.Count == 0)
                    return NoContent();

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
