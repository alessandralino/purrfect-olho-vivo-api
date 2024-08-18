 
using Microsoft.AspNetCore.Mvc;
using purrfect_olho_vivo_api.ViewModels.Responses; 
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.Interfaces;

namespace purrfect_olho_vivo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService _veiculoService;


        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;  
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoGetAllResponse>>> GetAll([FromQuery] VeiculoGetRequest request)
        {
            var responseList = await _veiculoService.GetAll(request);

            if (responseList == null || !responseList.Any())
            {
                return NotFound();
            }

            return Ok(responseList);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculoById(long id)
        {
            try
            {
                var veiculoWithLinha = await _veiculoService.GetVeiculoById(id);

                return veiculoWithLinha;
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
        }
         

        [HttpGet("veiculo/{idLinha}")]
        public async Task<ActionResult<Veiculo>> GetVeiculoByLinha(int idLinha)
        {
            var veiculo = await _veiculoService.GetVeiculoByLinha(idLinha);

            
            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }


        [HttpPost]
        public async Task<ActionResult<VeiculoCreateResponse>> Create(VeiculoCreateRequest request)
        {
            var veiculo = new Veiculo
            {
                Name = request.Name,
                Modelo = request.Modelo,
                LinhaId = request.linhaId
            };

            VeiculoCreateResponse veiculoResponse = new VeiculoCreateResponse();

            try
            {
                veiculoResponse = await _veiculoService.Create(request);

            }
            catch (KeyNotFoundException ex)
            {

                return BadRequest(ex.Message);
            } 

            return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculoResponse);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _veiculoService.Delete(id);
            
            if (success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VeiculoUpdateResponse>> Update(long id, VeiculoUpdateRequest request)
        {
            try
            {
                var veiculoResponse = await _veiculoService.Update(id, request);

                return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculoResponse.Id }, veiculoResponse);
            }
            catch (ArgumentException)
            {
                return BadRequest("ID do veículo não corresponde ao ID fornecido.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
         
    }
}
