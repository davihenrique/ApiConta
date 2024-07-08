using System.Diagnostics.CodeAnalysis;
using ApiConta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiConta.Infra.DatabaseContext;

[ExcludeFromCodeCoverage]
public class Context(DbContextOptions<Context> options) : DbContext(options)
{

    public DbSet<ContaEntity> Conta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContaEntity>(c => c.ToTable("CONTA_DATABASE")
        .HasKey(c => c.IdConta));

        modelBuilder.Entity<ContaEntity>().Property(c => c.IdConta)
            .HasColumnName("ID_CONTA");

        modelBuilder.Entity<ContaEntity>().Property(c => c.Nome)
            .HasColumnName("NOME_CONTA");

        modelBuilder.Entity<ContaEntity>().Property(c => c.ValorOriginal)
            .HasColumnName("VALOR_ORIGINAL_CONTA");

        modelBuilder.Entity<ContaEntity>().Property(c => c.ValorCorrigido)
            .HasColumnName("VALOR_CORRIGIDO_CONTA");

        modelBuilder.Entity<ContaEntity>().Property(c => c.DataVencimento)
            .HasColumnName("DATA_VENCIMENTO_CONTA");

        modelBuilder.Entity<ContaEntity>().Property(c => c.DataPagamento)
            .HasColumnName("DATA_PAGAMENTO_CONTA");

        modelBuilder.Entity<ContaEntity>().Property(c => c.DiasAtrasados)
            .HasColumnName("DIAS_ATRASADOS_CONTA");

        modelBuilder.Entity<ContaEntity>().Property(c => c.RegraCalculo)
            .HasColumnName("REGRA_CALCULO_CONTA");
    }
}
