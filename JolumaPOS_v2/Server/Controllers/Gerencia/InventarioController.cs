using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JolumaPOS_v2.Server.Models;
using JolumaPOS_v2.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData;

namespace JolumaPOS_v2.Server.Controllers.Gerencia
{
    [Authorize(Roles = "Gerente")]
    [ODataRoutePrefix("Inventarios")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ODataController
    {
        private readonly JolumaPOSDevContext _context;

        public InventarioController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/Inventario
        [HttpGet]
        [ODataRoute]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetInventarios(int idCaja)
        {
            var model = await _context.Inventarios.ToListAsync();

            if(idCaja != 0)
                model = model.Where(m => m.Caja == idCaja).ToList();

            return model;
        }

        // GET: api/Inventario/5
        [HttpGet("{id}")]
        [ODataRoute("({id})")]
        public async Task<ActionResult<Inventario>> GetInventario(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);

            if (inventario == null)
            {
                return NotFound();
            }

            return inventario;
        }


        // POST: api/Inventario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario(Inventario inventario)
        {
            _context.Inventarios.Add(inventario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventarioExists(inventario.Caja))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInventario", new { id = inventario.Caja }, inventario);
        }

        // DELETE: api/Inventario/5
        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventarioExists(int id)
        {
            return _context.Inventarios.Any(e => e.Caja == id);
        }
    }
}
