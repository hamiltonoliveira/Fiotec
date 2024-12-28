using Application.Interfaces;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlertaDengueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitanteController : ControllerBase
    {
        private readonly ISolicitanteService _solicitanteService;

        public SolicitanteController(ISolicitanteService solicitanteService)
        {
            _solicitanteService = solicitanteService;
        }

        [HttpPost("solicitante")]
        public async Task<IActionResult> InserirSolicitante([FromBody] SolicitanteDto solicitanteDto)
        {
            if (solicitanteDto == null)
            {
                return BadRequest("Dados do solicitante não podem estar nulos.");
            }

            try
            {
                var solicitante = new Solicitante
                {
                    Nome = solicitanteDto.Nome,
                    CPF = solicitanteDto.CPF
                };

                var resultado = await _solicitanteService.InsertAsync(solicitante);
                return CreatedAtAction(nameof(InserirSolicitante), new { id = resultado.Id }, resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log do erro (se necessário)
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
 
