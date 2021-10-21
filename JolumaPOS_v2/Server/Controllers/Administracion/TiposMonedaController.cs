using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JolumaPOS_v2.Server.Models;
using JolumaPOS_v2.Shared.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;

namespace JolumaPOS_v2.Server.Controllers.Administracion
{
    [Authorize(Roles = "Administrador, Gerente")]
    [ODataRoutePrefix("TiposMoneda")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposMonedaController : ODataController
    {
        private readonly JolumaPOSDevContext _context;

        public TiposMonedaController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/TiposMoneda
        [HttpGet]
        [ODataRoute]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMonedum>>> GetTipoMoneda()
        {
            return await _context.TipoMoneda.ToListAsync();
        }

        // GET: api/TiposMoneda/5
        [HttpGet("{id}")]
        [ODataRoute("({id})")]
        public async Task<ActionResult<TipoMonedum>> GetTipoMonedum(int id)
        {
            var tipoMonedum = await _context.TipoMoneda.FindAsync(id);

            if (tipoMonedum == null)
            {
                return NotFound();
            }

            return tipoMonedum;
        }

        // PUT: api/TiposMoneda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> PatchTipoMonedum(int id, TipoMonedum tipoMonedum)
        {
            if (id != tipoMonedum.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoMonedum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMonedumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TiposMoneda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoMonedum>> PostTipoMonedum(TipoMonedum tipoMonedum)
        {
            _context.TipoMoneda.Add(tipoMonedum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoMonedum", new { id = tipoMonedum.Id }, tipoMonedum);
        }

        // DELETE: api/TiposMoneda/5
        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> DeleteTipoMonedum(int id)
        {
            var tipoMonedum = await _context.TipoMoneda.FindAsync(id);
            if (tipoMonedum == null)
            {
                return NotFound();
            }

            _context.TipoMoneda.Remove(tipoMonedum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoMonedumExists(int id)
        {
            return _context.TipoMoneda.Any(e => e.Id == id);
        }
    }
}
