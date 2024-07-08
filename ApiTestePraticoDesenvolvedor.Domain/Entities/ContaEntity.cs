using System.Diagnostics.CodeAnalysis;

namespace ApiConta.Domain.Entities;

[ExcludeFromCodeCoverage]
public class ContaEntity
{
    public Guid IdConta { get; set; }
    public required string Nome { get; set; }
    public double ValorOriginal { get; set; }
    public double ValorCorrigido { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataPagamento { get; set; }
    public int DiasAtrasados { get; set; }
    public required string RegraCalculo { get; set; }
}
