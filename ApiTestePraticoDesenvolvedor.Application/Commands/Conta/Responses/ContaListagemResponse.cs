namespace ApiConta.Application.Commands.Conta.Responses;
public class ContaListagemResponse
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public double ValorOriginal { get; set; }
    public double ValorCorrigido { get; set; }
    public int QuantidadeDiasDeAtraso { get; set; }
    public DateTime DataPagamento { get; set; }
    public required string RegraCalculo { get; set; }
}
