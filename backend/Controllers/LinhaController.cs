using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Context;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;

namespace purrfect_olho_vivo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinhaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LinhaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Linha>>> GetAll()
        {
            return _context.Linhas
                       .Include(l => l.Paradas)
                       .ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Linha>> GetLinha(int id)
        {
            var linha =  _context.Linhas
                       .Include(l => l.Paradas)
                       .SingleOrDefault(l => l.Id == id);

            if (linha == null)
            {
                return NotFound();
            }

            return linha;
        }

        [HttpPost]
        public async Task<ActionResult<Linha>> Create(LinhaCreateRequest request)
        {
            var linha = new Linha
            {
                Name = request.Name,
                Paradas = new List<Parada>()
            };

            foreach (var paradaRequest in request.Paradas)
            { 
                var existingParada = await _context.Parada
                    .FirstOrDefaultAsync(p => p.Id == paradaRequest.Id);

                if (existingParada != null)
                { 
                    linha.Paradas.Add(existingParada);
                } 
                else
                { 
                    ModelState.AddModelError("Paradas", $"A parada '{paradaRequest.Name}' não foi encontrada no sistema.");
                    return BadRequest(ModelState);
                }
            }

            _context.Linhas.Add(linha);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = linha.Id }, linha);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Linha linha)
        {
            if (id != linha.Id)
            {
                return BadRequest();
            }

            _context.Entry(linha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinhaExists(id))
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

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinha(int id)
        {
            var linha = await _context.Linhas.FindAsync(id);
            if (linha == null)
            {
                return NotFound();
            }

            _context.Linhas.Remove(linha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LinhaExists(int id)
        {
            return _context.Linhas.Any(e => e.Id == id);
        }
    }
}

