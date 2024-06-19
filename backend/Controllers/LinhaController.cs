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
using purrfect_olho_vivo_api.Services;
using Azure.Core;

namespace purrfect_olho_vivo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinhaController : ControllerBase
    {
        private readonly ILinhaService _linhaService;

        public LinhaController(ILinhaService linhaService)
        {
            _linhaService = linhaService;
        }

        [HttpGet]
        public async Task<ActionResult<LinhaGetAllResponse>> GetAll()
        {
            var response = await _linhaService.GetAll();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Linha>> GetLinhaById(int id)
        {
            var linha = await _linhaService.GetLinhaById(id);

            if (linha == null)
            {
                return NotFound();
            }

            return linha;
        }

        [HttpPost]
        public async Task<ActionResult<Linha>> Create(LinhaCreateRequest request)
        {
            try
            {
                var linha = await _linhaService.CreateLinha(request);

                return CreatedAtAction(nameof(GetAll), new { id = linha.Id }, linha);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Linha>> Update(int id, LinhaUpdateRequest request)
        {
            try
            {
                var linha = await _linhaService.UpdateLinha(id, request);

                return Ok(linha);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinha(long id)
        {
            var success = await _linhaService.DeleteLinha(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpGet("parada/{idParada}")]
        public async Task<ActionResult<IEnumerable<Linha>>> GetLinhaPorParada(int idParada)
        {
            var linhas = await _linhaService.GetLinhaPorParada(idParada);

            if (linhas == null || !linhas.Any())
            {
                return NotFound();
            }
            return Ok(linhas);
        }
    }
}

