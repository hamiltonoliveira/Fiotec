using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlertaDengueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaDengueController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ISolicitanteService _solicitanteService;
        private readonly IRelatorioService _relatorioService;
        public AlertaDengueController(HttpClient httpClient, 
                                      ISolicitanteService solicitanteService,
                                      IRelatorioService relatorioService)
        {
            _httpClient = httpClient;
            _solicitanteService = solicitanteService;
            _relatorioService = relatorioService;
        }

        [HttpGet("consultar-alerta")]
        public async Task<IActionResult> ConsultarAlerta(
            [FromQuery] int solicitanteId,
            [FromQuery] int geocode,
            [FromQuery] string disease,
            [FromQuery] string format,
            [FromQuery] int ew_start,
            [FromQuery] int ew_end,
            [FromQuery] int ey_start,
            [FromQuery] int ey_end)
        {
            // Valida se os parâmetros obrigatórios foram passados corretamente
            if (solicitanteId <= 0 || string.IsNullOrEmpty(disease) || string.IsNullOrEmpty(format) ||
                geocode == 0 || ew_start <= 0 || ew_end <= 0 || ey_start <= 0 || ey_end <= 0)
            {
                return BadRequest("Parâmetros inválidos. Verifique se todos os parâmetros obrigatórios foram fornecidos.");
            }

            // Monta a URL com os parâmetros fornecidos
            var url = $"https://info.dengue.mat.br/api/alertcity?geocode={geocode}&disease={disease}&format={format}&ew_start={ew_start}&ew_end={ew_end}&ey_start={ey_start}&ey_end={ey_end}";

            try
            {
                // Faz a requisição HTTP para a API externa
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // Verifica se o solicitante é válido antes de prosseguir
                    var solicitante = await _solicitanteService.GetSolicitanteAsync(solicitanteId);
                    if (solicitante?.Id > 0)
                    {
                        var relatorio = new Relatorio
                        {
                            DataSolicitacao = DateTime.Now,
                            Arbovirose = disease,
                            SemanaInicio = ew_start,
                            SemanaTermino = ew_end,
                            CodigoIBGE = geocode.ToString(),
                            SolicitanteId = solicitanteId
                        };

                        // Chama o serviço para inserir o relatório
                        var resultadoRelatorio = await _relatorioService.InsertRelatorioAsync(relatorio);

                        // Retorna a resposta conforme o formato solicitado
                        if (format.ToLower() == "json")
                        {
                            return Ok(content); // Retorna os dados em formato JSON
                        }
                        else if (format.ToLower() == "csv")
                        {
                            return File(System.Text.Encoding.UTF8.GetBytes(content), "text/csv", "alerta_dengue.csv");
                        }
                        else
                        {
                            return BadRequest("Formato inválido. Aceitamos apenas 'json' ou 'csv'.");
                        }
                    }
                    else
                    {
                        return BadRequest("Solicitante não encontrado ou ID inválido.");
                    }
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Erro ao acessar os dados da API externa.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
