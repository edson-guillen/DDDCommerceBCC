using Microsoft.AspNetCore.Mvc;
using DDDCommerceBCC.Domain;
using DDDCommerceBCC.Infra.Interfaces;
using System.Collections.Generic;

namespace DDDCommerceBCC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        // GET: api/Pedido
        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetPedidos()
        {
            return Ok(_pedidoRepository.GetAllPedidos());
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = _pedidoRepository.GetPedidoById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        // POST: api/Pedido
        [HttpPost]
        public ActionResult<Pedido> PostPedido(Pedido pedido)
        {
            _pedidoRepository.AddPedido(pedido);
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
        }

        // PUT: api/Pedido/5
        [HttpPut("{id}")]
        public IActionResult PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            try
            {
                _pedidoRepository.UpdatePedido(id, pedido);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var pedido = _pedidoRepository.GetPedidoById(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _pedidoRepository.DeletePedido(id);
            return NoContent();
        }
    }
}
