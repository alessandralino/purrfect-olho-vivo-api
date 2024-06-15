using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Context;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;

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
    }
}
