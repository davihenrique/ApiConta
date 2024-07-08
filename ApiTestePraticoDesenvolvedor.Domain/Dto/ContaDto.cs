namespace ApiConta.Domain.Dto;
public class ContaDto
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public double ValorOriginal { get; set; }
    public double ValorCorrigido { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataPagamento { get; set; }
    public int DiasAtrasados { get; set; }
    public string? RegraCalculo { get; set; }
}
