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
    [Authorize(Roles = "Administrador")]
    [ODataRoutePrefix("Proveedores")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ODataController
    {
        private readonly JolumaPOSDevContext _context;

        public ProveedoresController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/Proveedores
        [HttpGet]
        [ODataRoute]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedors()
        {
            return await _context.Proveedors.ToListAsync();
        }

        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        [ODataRoute("({id})")]
        public async Task<ActionResult<Proveedor>> GetProveedor(int id)
        {
            var proveedor = await _context.Proveedors.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        // PUT: api/Proveedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> PatchProveedor(int id, [FromBody] ProveedorViewModel proveedor)
        {
            if (proveedor != null)
            {
                if (id != proveedor.Id)
                {
                    return BadRequest();
                }
                else if (ProveedorExists(id))
                {
                    var model = _context.Proveedors.Where(m => m.Id == id).FirstOrDefault();

                    model.RazonSocial = !string.IsNullOrEmpty(proveedor.RazonSocial) ? proveedor.RazonSocial : model.RazonSocial;
                    model.Rfc = !string.IsNullOrEmpty(proveedor.Rfc) ? proveedor.Rfc : model.Rfc;
                    model.CalleDireccion = !string.IsNullOrEmpty(proveedor.CalleDireccion) ? proveedor.CalleDireccion : model.CalleDireccion;
                    model.NumDireccion = !string.IsNullOrEmpty(proveedor.NumDireccion) ? proveedor.NumDireccion : model.NumDireccion;
                    model.ColDireccion = !string.IsNullOrEmpty(proveedor.ColDireccion) ? proveedor.ColDireccion : model.ColDireccion;
                    model.Pais = !string.IsNullOrEmpty(proveedor.Pais) ? proveedor.Pais : model.Pais;
                    model.Estado = !string.IsNullOrEmpty(proveedor.Estado) ? proveedor.Estado : model.Estado;
                    model.Municipio = !string.IsNullOrEmpty(proveedor.Municipio) ? proveedor.Municipio : model.Municipio;
                    model.Status = proveedor.Status != model.Status ? proveedor.Status : model.Status;

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

        // POST: api/Proveedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
            _context.Proveedors.Add(proveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProveedor", new { id = proveedor.Id }, proveedor);
        }

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            var proveedor = await _context.Proveedors.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedors.Remove(proveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedors.Any(e => e.Id == id);
        }
    }
}
