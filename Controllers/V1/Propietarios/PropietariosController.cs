using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Data;

namespace Taller.Controllers.V1.Propietarios
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PropietariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PropietariosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Propietarios = await _context.Propietarios.ToListAsync();
            return Ok(Propietarios);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropietarioById(int id)
        {
            var Propietarios = await _context.Propietarios.FindAsync(id);
            return Ok(Propietarios);
        }

        [HttpGet("FindByName/{name}")]
        public async Task<IActionResult> GetPropietarioByName(string name)
        {
            var Propietarios = await _context.Propietarios.FirstOrDefaultAsync(p => p.Nombre.Contains(name));
            return Ok(Propietarios);
        }
        [HttpGet("FindByInitial/{initial}")]
        public async Task<IActionResult> GetOwnerByInitial(string initial)
        {
            var PropietarioTraidoDeLaBaseDeDatos = await _context.Propietarios.Where(p => p.Nombre.StartsWith(initial)).ToListAsync();
            return Ok(PropietarioTraidoDeLaBaseDeDatos);
        }
    }
}