namespace ApiConta.Application.Commands.Conta.Requests;

public class ContaIncluirRequest
{
    public string? Nome { get; set; }
    public double? ValorOriginal { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataPagamento { get; set; }
}
