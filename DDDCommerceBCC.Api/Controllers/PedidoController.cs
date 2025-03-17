using DDDCommerceBCC.Domain;
using DDDCommerceBCC.Infra;
using DDDCommerceBCC.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DDDCommerceBCC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _context;

        public PedidosController(IPedidoRepository context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public ActionResult<List<Pedido>> GetPedidos()
        {
            return _context.GetAll();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = _context.GetPedidoById(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        //// PUT: api/Pedidos/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        //{
        //    if (id != pedido.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(pedido).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PedidoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Pedidos

        [HttpPost]
        public ActionResult<Pedido> PostPedido(Pedido pedido)
        {
            _context.AddPedido(pedido);
            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            if (_context.DeletePedido(id)) 
            return Ok("Pedido Deletado com sucesso");

            return NotFound("Id nao encontrado");
        }

    }
}
