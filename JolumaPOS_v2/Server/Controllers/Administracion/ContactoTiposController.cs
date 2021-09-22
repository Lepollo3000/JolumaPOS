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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.OData.Routing;

namespace JolumaPOS_v2.Server.Controllers.Administracion
{
    [Authorize(Roles = "Administrador")]
    [ODataRoutePrefix("ContactoTipos")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoTiposController : ODataController
    {
        private readonly JolumaPOSDevContext _context;

        public ContactoTiposController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/ContactoTipos
        [HttpGet]
        [ODataRoute]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<ContactoTipo>>> GetContactoTipos()
        {
            return await _context.ContactoTipos.ToListAsync();
        }
        /*
        // GET: api/ContactoTipos/5
        [HttpGet("{id}")]
        [ODataRoute("({id})")]
        public async Task<ActionResult<ContactoTipo>> GetContactoTipo(int id)
        {
            var contactoTipo = await _context.ContactoTipos.FindAsync(id);

            if (contactoTipo == null)
            {
                return NotFound();
            }

            return contactoTipo;
        }

        // PUT: api/ContactoTipos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> PatchContactoTipo(int id, ContactoTipo contactoTipo)
        {
            if (id != contactoTipo.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactoTipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoTipoExists(id))
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

        // POST: api/ContactoTipos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactoTipo>> PostContactoTipo(ContactoTipo contactoTipo)
        {
            _context.ContactoTipos.Add(contactoTipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactoTipo", new { id = contactoTipo.Id }, contactoTipo);
        }

        // DELETE: api/ContactoTipos/5
        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> DeleteContactoTipo(int id)
        {
            var contactoTipo = await _context.ContactoTipos.FindAsync(id);
            if (contactoTipo == null)
            {
                return NotFound();
            }

            _context.ContactoTipos.Remove(contactoTipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactoTipoExists(int id)
        {
            return _context.ContactoTipos.Any(e => e.Id == id);
        }
        */
    }
}
