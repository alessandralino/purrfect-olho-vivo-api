using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Context;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses;

namespace purrfect_olho_vivo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadaController : Controller
    {
        private readonly AppDbContext _context;

        public ParadaController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parada>> GetParadaById(int id)
        {
            var parada = await _context.Parada.FindAsync(id);

            if (parada == null)
            {
                return NotFound();
            } 

            return parada;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parada>>> GetAll()
        {
            return _context.Parada.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Parada>> Create(ParadaCreateRequest request)
        {
            var parada = new Parada
            {    
                Name = request.Name,
                Latitude = request.Latitude,   
                Longitude = request.Longitude,                                                              
            };
            
            _context.Parada.Add(parada);
            _context.SaveChanges(); 
            
            return Ok(parada);
        }

        [HttpPost("posicao")]
        public async Task<ActionResult<IEnumerable<Parada>>> GetParadaByPosicao(ParadaGetByPosicaoRequest request)
        {
            var paradas = _context.Parada
                .Where((p => p.Latitude == request.latitude && p.Latitude == request.latitude))
                .ToList();

            if (paradas == null || !paradas.Any())
            {
                return BadRequest();
            }

            return Ok(paradas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParadaUpdateResponse>> Update(int id, Parada parada)
        {
            if (id != parada.Id)
            {
                return BadRequest();
            }

            var veiculoResponse = new ParadaUpdateResponse();

            try
            {
                _context.Entry(parada).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                var paradaAtualizada = await _context.Parada.FirstOrDefaultAsync(v => v.Id == parada.Id);

                if (paradaAtualizada == null)
                {
                    return NotFound();
                }

                veiculoResponse = new ParadaUpdateResponse()
                {
                    Id = paradaAtualizada.Id,
                    Latitude = paradaAtualizada.Latitude,
                    Longitude = paradaAtualizada.Longitude,
                    Name = paradaAtualizada.Name
                };

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParadaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(veiculoResponse);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var parada = await _context.Parada.FindAsync(id);
            if (parada == null)
            {
                return NotFound();
            }

            _context.Parada.Remove(parada);
            await _context.SaveChangesAsync();

            return NoContent();
        }
         
        private bool ParadaExists(int id)
        {
            return _context.Parada.Any(e => e.Id == id);
        }
    }
}
