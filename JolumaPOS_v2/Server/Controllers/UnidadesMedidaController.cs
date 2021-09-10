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

namespace JolumaPOS_v2.Server.Controllers
{
    [Authorize]
    [ODataRoutePrefix("UnidadesMedida")]
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMedidaController : ODataController
    {
        private readonly JolumaPOSDevContext _context;

        public UnidadesMedidaController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/UnidadesMedida
        [HttpGet]
        [ODataRoute]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<UnidadMedidum>>> GetUnidadMedida()
        {
            return await _context.UnidadMedida.ToListAsync();
        }

        // GET: api/UnidadesMedida/5
        [HttpGet("{id}")]
        [ODataRoute("({id})")]
        public async Task<ActionResult<UnidadMedidum>> GetUnidadMedidum(int id)
        {
            var unidadMedidum = await _context.UnidadMedida.FindAsync(id);

            if (unidadMedidum == null)
            {
                return NotFound();
            }

            return unidadMedidum;
        }

        // PUT: api/UnidadesMedida/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> PutUnidadMedidum(int id, UnidadMedidum unidadMedidum)
        {
            if (id != unidadMedidum.Id)
            {
                return BadRequest();
            }

            _context.Entry(unidadMedidum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadMedidumExists(id))
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

        // POST: api/UnidadesMedida
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnidadMedidum>> PostUnidadMedidum(UnidadMedidum unidadMedidum)
        {
            _context.UnidadMedida.Add(unidadMedidum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadMedidum", new { id = unidadMedidum.Id }, unidadMedidum);
        }

        // DELETE: api/UnidadesMedida/5
        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> DeleteUnidadMedidum(int id)
        {
            var unidadMedidum = await _context.UnidadMedida.FindAsync(id);
            if (unidadMedidum == null)
            {
                return NotFound();
            }

            _context.UnidadMedida.Remove(unidadMedidum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadMedidumExists(int id)
        {
            return _context.UnidadMedida.Any(e => e.Id == id);
        }
    }
}
