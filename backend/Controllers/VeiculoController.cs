 
using Microsoft.AspNetCore.Mvc;
using purrfect_olho_vivo_api.ViewModels.Responses;
using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Context;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;

namespace purrfect_olho_vivo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : Controller
    {
        private readonly AppDbContext _context;

        public VeiculoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoGetAllResponse>>> GetAll()
        {
            var lista = await _context.Veiculo.Include(v => v.Linha).ToListAsync();

            var responseList = lista.Select(v => new VeiculoGetAllResponse
            {
                Id = v.Id,
                Name = v.Name,
                Modelo = v.Modelo,
                Linha = new Linha
                {
                    Id = v.Linha.Id,
                    Name = v.Linha.Name,
                }
            }).ToList();

            return Ok(responseList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculoById(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            var veiculoWithLinha = await _context.Veiculo
            .Include(v => v.Linha)
            .FirstOrDefaultAsync(v => v.Id == veiculo.Id); 

            return veiculoWithLinha;
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoCreateResponse>> Create(VeiculoCreateRequest request)
        {
            var veiculo = new Veiculo
            {
                Name = request.Name,
                Modelo = request.Modelo,   
                //LinhaFkId = request.linhaId
            };

            _context.Veiculo.Add(veiculo); 

            await _context.SaveChangesAsync();

            var veiculoWithLinha = await _context.Veiculo
           .Include(v => v.Linha)
           .FirstOrDefaultAsync(v => v.Id == veiculo.Id);

            if (veiculoWithLinha == null)
            {
                return NotFound();
            }

            var veiculoResponse = new VeiculoCreateResponse
            {
                Id = veiculoWithLinha.Id,
                Name = veiculoWithLinha.Name,
                Modelo = veiculoWithLinha.Modelo,
                Linha = new Linha
                {
                    Id = veiculoWithLinha.Linha.Id,
                    Name = veiculoWithLinha.Linha.Name, 
                }
            };

            return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculoResponse);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VeiculoUpdateResponse>> Update(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(veiculo).State = EntityState.Modified;

            var veiculoResponse = new VeiculoUpdateResponse();

            try
            {
                await _context.SaveChangesAsync();

                var veiculoWithLinha = await _context.Veiculo
           .Include(v => v.Linha)
           .FirstOrDefaultAsync(v => v.Id == veiculo.Id);

                if (veiculoWithLinha == null)
                {
                    return NotFound();
                }

                veiculoResponse = new VeiculoUpdateResponse
                {
                    Id = veiculoWithLinha.Id,
                    Name = veiculoWithLinha.Name,
                    Modelo = veiculoWithLinha.Modelo,
                    Linha = new Linha
                    {
                        Id = veiculoWithLinha.Linha.Id,
                        Name = veiculoWithLinha.Linha.Name,
                    }
                };
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculoResponse);
        }


        private bool VeiculoExists(int id)
        {
            return _context.Veiculo.Any(e => e.Id == id);
        }
    }
}
