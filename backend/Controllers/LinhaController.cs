using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Context;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses;
using System.Collections.Immutable;
using System.Text.Json.Serialization;
using System.Text.Json;

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
        public async Task<ActionResult<LinhaGetAllResponse>> GetAll()
        {
            var linhas = _context.Linha.Include(l => l.Paradas).ToList();

            var options = linhas.Select(l => new LinhaGetAllResponse
            {
                Id = l.Id,
                Name = l.Name,
                Paradas = l.Paradas.Select(p => new Parada
                {
                    Id = p.Id,
                    Name = p.Name,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude
                }).ToList()
            }).ToList();

            return Ok(options);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Linha>> GetLinha(int id)
        {
            var linha =  _context.Linha
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
                    .FirstOrDefaultAsync(p => p.Id == paradaRequest);

                if (existingParada != null)
                {
                    linha.Paradas.Add(existingParada);
                }
                else
                {
                    return BadRequest($"A parada '{paradaRequest}' não foi encontrada no sistema.");
                }
            }

            _context.Linha.Add(linha);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = linha.Id }, linha);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Linha>> Update(int id, LinhaUpdateRequest linhaUpdateRequest)
        {
            if (id != linhaUpdateRequest.Id)
            {
                return BadRequest();
            }

            var linha = await _context.Linha.Include(l => l.Paradas).FirstOrDefaultAsync(l => l.Id == id);

            if (linha == null)
            {
                return NotFound();
            }

            linha.Name = linhaUpdateRequest.Name;

            var paradas = await _context.Parada.Where(p => linhaUpdateRequest.Paradas.Contains(p.Id)).ToListAsync();
            
            linha.Paradas.Clear();

            foreach (var parada in paradas)
            {
                linha.Paradas.Add(parada);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Linha.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(linha);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinha(int id)
        {
            var linha = await _context.Linha.FindAsync(id);
            if (linha == null)
            {
                return NotFound();
            }

            _context.Linha.Remove(linha);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("parada/{idParada}")]
        public async Task<ActionResult<IEnumerable<Linha>>> GetLinhaPorParada(int idParada)
        {
            var linhas = await _context.Linha
                .Include(l => l.Paradas)
                .Where(l => l.Paradas.Any(p => p.Id == idParada))
                .ToListAsync();

            if (linhas == null || !linhas.Any())
            {
                return NotFound();
            }

            return Ok(linhas);
        }


        private bool LinhaExists(int id)
        {
            return _context.Linha.Any(e => e.Id == id);
        }
    }
}

