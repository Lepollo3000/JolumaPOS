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
    public class ListaCajasController : ControllerBase
    {
        private readonly JolumaPOSDevContext _context;

        public ListaCajasController(JolumaPOSDevContext context)
        {
            _context = context;
        }

        // GET: api/ListaCajas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caja>>> GetCajas()
        {
            return await _context.Cajas.Where(c => c.Estatus == true).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Caja>> GetCaja(int id)
        {
            var caja = await _context.Cajas.FindAsync(id);

            if (caja == null)
            {
                return NotFound();
            }

            return caja;
        }
    }
}
