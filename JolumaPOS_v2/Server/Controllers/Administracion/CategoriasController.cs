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
using JolumaPOS_v2.Shared.ViewModels;

namespace JolumaPOS_v2.Server.Controllers.Administracion
{
    [Authorize(Roles = "Administrador")]
    [ODataRoutePrefix("Categorias")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ODataController
    {
        private readonly JolumaPOSDevContext _context;

        public CategoriasController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        [ODataRoute]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Categorium>>> GetCategoria(bool mostrarFiltrado = false, bool mostrarNulo = false)
        {
            var model = await _context.Categoria.ToListAsync();

            if (mostrarFiltrado)
                model = model.Where(m => m.Status == true).ToList();
            if (mostrarNulo)
            {
                var categoriaNula = new Categorium()
                {
                    Id = 0,
                    Descripcion = "Ninguna",
                    Status = true
                };

                model.Insert(0, categoriaNula);
            }

            return model;
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        [ODataRoute("({id})")]
        public async Task<ActionResult<Categorium>> GetCategorium(int id)
        {
            var categorium = await _context.Categoria.FindAsync(id);

            if (categorium == null)
            {
                return NotFound();
            }

            return categorium;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> PatchCategorium(int id, [FromBody] CategoriaViewModel categorium)
        {
            if (categorium != null)
            {
                if (id != categorium.Id)
                {
                    return BadRequest();
                }
                else if (CategoriumExists(id))
                {
                    var model = _context.Categoria.Where(c => c.Id == id).FirstOrDefault();

                    categorium.Padre = categorium.Padre == 0 ? null : categorium.Padre;

                    model.Padre = (model.Padre == null && categorium.Padre != null)
                        || (model.Padre != null && categorium.Padre == null)
                        ? categorium.Padre : model.Padre;
                    model.Descripcion = categorium.Descripcion != null ? categorium.Descripcion : model.Descripcion;
                    model.Status = categorium.Status != model.Status ? categorium.Status : model.Status;

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

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorium>> PostCategorium(Categorium categorium)
        {
            categorium.Padre = categorium.Padre != 0 ? categorium.Padre : null;

            _context.Categoria.Add(categorium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorium", new { id = categorium.Id }, categorium);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public async Task<IActionResult> DeleteCategorium(int id)
        {
            var categorium = await _context.Categoria.FindAsync(id);
            if (categorium == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categorium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriumExists(int id)
        {
            return _context.Categoria.Any(e => e.Id == id);
        }
    }
}
