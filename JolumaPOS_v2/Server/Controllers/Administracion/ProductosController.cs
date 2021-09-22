using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JolumaPOS_v2.Server.Models;
using JolumaPOS_v2.Shared.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using JolumaPOS_v2.Shared.ViewModels;

namespace JolumaPOS_v2.Server.Controllers.Administracion
{
    [Authorize(Roles = "Administrador")]
    [ODataRoutePrefix("Productos")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ODataController
    {
        private readonly JolumaPOSDevContext _context;

        public ProductosController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        [ODataRoute]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var model = await _context.Productos.ToListAsync();
            return model;
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        [ODataRoute("({id})")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> PatchProducto([FromBody] ProductoViewModel producto, int id)
        {
            if (producto != null)
            {
                if (id != producto.Id)
                {
                    return BadRequest();
                }
                else if (ProductoExists(producto.Id))
                {
                    var model = _context.Productos.Where(m => m.Id == producto.Id).FirstOrDefault();

                    model.CodigoBarras = producto.CodigoBarras != null ? producto.CodigoBarras : model.CodigoBarras;
                    model.Nombre = producto.Nombre != null ? producto.Nombre : model.Nombre;
                    model.DescripcionProducto = producto.DescripcionProducto != null ? producto.DescripcionProducto : model.DescripcionProducto;
                    model.Categoria = producto.Categoria != 0 ? producto.Categoria : model.Categoria;
                    model.UnidadMedida = producto.UnidadMedida != 0 ? producto.UnidadMedida : model.UnidadMedida;
                    model.Status = producto.Status != model.Status ? producto.Status : model.Status;
                    model.RequiereInventario = producto.RequiereInventario != model.RequiereInventario ? producto.RequiereInventario : model.RequiereInventario;

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

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
