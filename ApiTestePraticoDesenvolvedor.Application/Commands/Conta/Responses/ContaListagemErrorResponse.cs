namespace ApiConta.Application.Commands.Conta.Responses;
public class ContaListagemErrorResponse
{
    public required IEnumerable<string> Mensagens { get; set; }
}
