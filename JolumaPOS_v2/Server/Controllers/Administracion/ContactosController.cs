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
using JolumaPOS_v2.Shared.ViewModels;

namespace JolumaPOS_v2.Server.Controllers.Administracion
{
    [Authorize]
    [ODataRoutePrefix("Contactos")] 
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ODataController
    {
        private readonly JolumaPOSDevContext _context;

        public ContactosController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/Contactos
        [HttpGet]
        [ODataRoute]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContactos()
        {
            return await _context.Contactos.ToListAsync();
        }

        // GET: api/Contactos/5
        [HttpGet("{id}")]
        [ODataRoute("({id})")]
        public async Task<ActionResult<Contacto>> GetContacto(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return contacto;
        }

        // PUT: api/Contactos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> PatchContacto(int id, [FromBody] ContactoViewModel contacto)
        {
            if (contacto != null)
            {
                if (id != contacto.Id)
                {
                    return BadRequest();
                }
                else if (ContactoExists(id))
                {
                    var model = _context.Contactos.Where(m => m.Id == id).FirstOrDefault();

                    model.Proveedor = contacto.Proveedor != 0 ? contacto.Proveedor : model.Proveedor;
                    model.TipoContacto = contacto.TipoContacto != 0 ? contacto.TipoContacto : model.TipoContacto;
                    model.Nombre = string.IsNullOrEmpty(contacto.Nombre) ? model.Nombre : contacto.Nombre;
                    model.Email = string.IsNullOrEmpty(contacto.Email) ? model.Email : contacto.Email;
                    model.Telefono = string.IsNullOrEmpty(contacto.Telefono) ? model.Telefono : contacto.Telefono;
                    model.Status = contacto.Status != model.Status ? contacto.Status : model.Status;

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

        // POST: api/Contactos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContacto", new { id = contacto.Id }, contacto);
        }

        // DELETE: api/Contactos/5
        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> DeleteContacto(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactoExists(int id)
        {
            return _context.Contactos.Any(e => e.Id == id);
        }
    }
}
