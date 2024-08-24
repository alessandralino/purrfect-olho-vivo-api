using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses;
using purrfect_olho_vivo_api.Interfaces;
using purrfect_olho_vivo_api.Extensions;
using purrfect_olho_vivo_api.Models.Requests;

namespace purrfect_olho_vivo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadaController : Controller
    {
        private readonly IParadaService _paradaService;

        public ParadaController (IParadaService paradaService)
        {
            _paradaService = paradaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parada>>> GetAll([FromQuery] ParadaGetRequest request)
        {
            try
            {
                var paradas = await _paradaService.GetAll(request);

                Response.AddPaginationHeader(
                    new PaginationHeader(
                        request.pageNumber,
                        request.pageSize, 
                        paradas.Count(), 
                        paradas.TotalPages));

                return Ok(paradas);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parada>> GetParadaById(long id)
        {
            try
            {
                var parada = await _paradaService.GetParadaById(id); 

                return parada;
            }
            catch (KeyNotFoundException)
            {

                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Parada>> Create(ParadaCreateRequest request)
        { 
            try
            {
                var parada = await _paradaService.Create(request);

                return Ok(parada);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("posicao")]
        public async Task<ActionResult<Parada>> GetParadaByPosicao(ParadaGetByPosicaoRequest request)
        { 
            try
            {
                var paradas = await _paradaService.GetParadaByPosicao(request);

                return Ok(paradas);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParadaUpdateResponse>> Update(int id, Parada parada)
        {
            if (id != parada.Id)
            {
                return BadRequest("ID desconhecido. Informe um ID igual ao da Parada desejada.");
            }

            try
            {
                var paradaResponse = await _paradaService.Update(id, parada);

                return Ok(paradaResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_paradaService.ParadaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var success = await  _paradaService.Delete(id);

            if (!success)
            {
                return NotFound();
            }
             
            return NoContent();
        }
    }
}
