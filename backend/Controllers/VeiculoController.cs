using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetAll()
        {
            return await _context.Veiculo.ToListAsync();
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
        public async Task<ActionResult<Veiculo>> Create(VeiculoCreateRequest request)
        {
            var veiculo = new Veiculo
            {
                Name = request.Name,
                Modelo = request.Modelo,   
                LinhaFkId = request.linhaId
            };

            _context.Veiculo.Add(veiculo); 

            await _context.SaveChangesAsync();

            var veiculoWithLinha = await _context.Veiculo
            .Include(v => v.Linha)
            .FirstOrDefaultAsync(v => v.Id == veiculo.Id);

            return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculoWithLinha);
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

    }        
}
