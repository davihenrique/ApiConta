using ApiConta.Application.Commands.Conta.Enum;
using ApiConta.Application.Commands.Conta.Requests;
using ApiConta.Application.Commands.Conta.Responses;
using ApiConta.Application.Interfaces.Conta;
using Microsoft.AspNetCore.Mvc;

namespace ApiConta.Api.Controllers;

[ApiController]
[Route("/")]
public class ContaController(IContaService contaService) : ControllerBase
{
    private readonly IContaService _contaService = contaService;

    [HttpPost]
    [Route("IncluirConta")]
    [ProducesResponseType<ContaIncluirResponse>(StatusCodes.Status201Created)]
    public IActionResult IncluirConta([FromBody] ContaIncluirRequest request)
    {

        var result = _contaService.Incluir(request);

        if (result.Status != StatusConta.ContaIncluida)
        {
            return UnprocessableEntity(result);
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("Consultar")]
    [ProducesResponseType<ContaListagemResponse>(StatusCodes.Status200OK)]
    public IActionResult Consultar([FromQuery] string? id)
    {
        var contas = _contaService.Listar(id);

        if (!contas.Any())
        {
            return UnprocessableEntity(new ContaListagemErrorResponse
            {
                Mensagens = ["Nenhuma Conta Encontrada."]
            });
        }
        return Ok(contas);
    }
}
