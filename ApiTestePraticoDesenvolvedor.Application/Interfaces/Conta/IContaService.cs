using ApiConta.Application.Commands.Conta.Requests;
using ApiConta.Application.Commands.Conta.Responses;

namespace ApiConta.Application.Interfaces.Conta;
public interface IContaService
{
    ContaIncluirResponse Incluir(ContaIncluirRequest request);
    IEnumerable<ContaListagemResponse> Listar(string? idConta);
}
