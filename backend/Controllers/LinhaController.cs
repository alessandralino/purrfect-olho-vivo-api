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
            return await _context.Linhas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Linha>> GetLinha(int id)
        {
            var linha = await _context.Linhas.FindAsync(id);

            if (linha == null)
            {
                return NotFound();
            }

            return linha;
        }

        [HttpPost]
        public async Task<ActionResult<Linha>> criar(LinhaCreateRequest request)
        {
            var linha = new Linha
            {
                Name = request.Name
            };

            _context.Linhas.Add(linha);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLinha), new { id = linha.Id }, linha);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLinha(int id, Linha linha)
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

