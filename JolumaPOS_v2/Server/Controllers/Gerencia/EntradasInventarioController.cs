using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JolumaPOS_v2.Server.Models;
using JolumaPOS_v2.Shared.Models;

namespace JolumaPOS_v2.Server.Controllers.Gerencia
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradasInventarioController : ControllerBase
    {
        private readonly JolumaPOSDevContext _context;

        public EntradasInventarioController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/InventarioEntradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventarioEntradum>>> GetInventarioEntrada()
        {
            return await _context.InventarioEntrada.ToListAsync();
        }

        // GET: api/InventarioEntradas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventarioEntradum>> GetInventarioEntradum(int id)
        {
            var inventarioEntradum = await _context.InventarioEntrada.FindAsync(id);

            if (inventarioEntradum == null)
            {
                return NotFound();
            }

            return inventarioEntradum;
        }

        // POST: api/InventarioEntradas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventarioEntradum>> PostInventarioEntradum(InventarioEntradum inventarioEntradum)
        {
            _context.InventarioEntrada.Add(inventarioEntradum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventarioEntradum", new { id = inventarioEntradum.Id }, inventarioEntradum);
        }

        // DELETE: api/InventarioEntradas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventarioEntradum(int id)
        {
            var inventarioEntradum = await _context.InventarioEntrada.FindAsync(id);
            if (inventarioEntradum == null)
            {
                return NotFound();
            }

            _context.InventarioEntrada.Remove(inventarioEntradum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventarioEntradumExists(int id)
        {
            return _context.InventarioEntrada.Any(e => e.Id == id);
        }
    }
}
