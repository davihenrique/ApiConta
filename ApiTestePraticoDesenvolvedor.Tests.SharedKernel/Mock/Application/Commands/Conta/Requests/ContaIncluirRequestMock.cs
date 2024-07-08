using ApiConta.Application.Commands.Conta.Requests;

namespace ApiConta.Tests.SharedKernel.Mock.Application.Commands.Conta.Requests;
public static class ContaIncluirRequestMock
{
    public static ContaIncluirRequest GetMocked()
    {
        return new ContaIncluirRequest
        {
            Nome = "Conta de Luz",
            ValorOriginal = 200,
            DataVencimento = DateTime.Now,
            DataPagamento = DateTime.Now
        };
    }
}
