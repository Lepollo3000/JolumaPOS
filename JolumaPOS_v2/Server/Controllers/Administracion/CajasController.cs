using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JolumaPOS_v2.Server.Models;
using JolumaPOS_v2.Shared.Models;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;

namespace JolumaPOS_v2.Server.Controllers.Administracion
{
    [Authorize(Roles = "Administrador")]
    [ODataRoutePrefix("Cajas")]
    [Route("api/[controller]")]
    [ApiController]
    public class CajasController : ODataController
    {
        private readonly JolumaPOSDevContext _context;

        public CajasController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/Cajas
        [HttpGet]
        [ODataRoute]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Caja>>> GetCajas()
        {
            return await _context.Cajas.ToListAsync();
        }

        // GET: api/Cajas/5
        [HttpGet("{id}")]
        [ODataRoute("({id})")]
        public async Task<ActionResult<Caja>> GetCaja(int id)
        {
            var caja = await _context.Cajas.FindAsync(id);

            if (caja == null)
            {
                return NotFound();
            }

            return caja;
        }

        // PUT: api/Cajas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> PatchCaja(int id, [FromBody] Caja caja)
        {
            if (caja != null)
            {
                if (id != caja.Id)
                {
                    return BadRequest();
                }
                else if (CajaExists(id))
                {
                    var model = _context.Cajas.Where(m => m.Id == caja.Id).FirstOrDefault();

                    model.Descripcion = string.IsNullOrEmpty(caja.Descripcion) ? model.Descripcion : caja.Descripcion;
                    model.Estatus = model.Estatus != caja.Estatus ? caja.Estatus : model.Estatus;

                    _context.Entry(model).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        return StatusCode(500, ex);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, ex);

                    }
                }
                else
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Cajas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Caja>> PostCaja(Caja caja)
        {
            _context.Cajas.Add(caja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaja", new { id = caja.Id }, caja);
        }

        // DELETE: api/Cajas/5
        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> DeleteCaja(int id)
        {
            var caja = await _context.Cajas.FindAsync(id);
            if (caja == null)
            {
                return NotFound();
            }

            _context.Cajas.Remove(caja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CajaExists(int id)
        {
            return _context.Cajas.Any(e => e.Id == id);
        }
    }
}
