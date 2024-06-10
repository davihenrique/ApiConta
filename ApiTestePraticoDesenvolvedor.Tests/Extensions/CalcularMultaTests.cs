﻿using ApiTestePraticoDesenvolvedor.Application.Extensions;
using ApiTestePraticoDesenvolvedor.Domain.Dto;
using FluentAssertions;

namespace ApiTestePraticoDesenvolvedor.Tests.EcontaDtotensions;
public class CalcularMultaTests
{
    [Fact(DisplayName = "Deve Retornar Sem Multas e Juros")]
    public void DeveRetonarSemMultasEjuros()
    {
        var dataAtual = DateTime.Now;
        var contaDto = new ContaDto
        {
            DataPagamento = dataAtual,
            DataVencimento = dataAtual,
        };

        contaDto = CalculoMulta.CalcularMultaEJuros(contaDto);

        contaDto.Should().NotBeNull();
        contaDto.DiasAtrasados.Should().Be(0);
        contaDto.RegraCalculo.Should().Be(string.Empty);
        contaDto.ValorCorrigido.Should().Be(contaDto.ValorOriginal);

    }

    [Theory(DisplayName = "Deve Retonar Com Multa E Juros")]
    [InlineData(3, 0.02, 0.01)]
    [InlineData(10, 0.03, 0.02)]
    [InlineData(15, 0.05, 0.05)]
    public void DeveRetonarMultasEjuros(int dias, double multa, double juros)
    {
        var dataAtual = DateTime.Now;
        var contaDto = new ContaDto
        {
            ValorOriginal = 100,
            DataPagamento = dataAtual.AddDays(dias),
            DataVencimento = dataAtual,
        };

        contaDto = CalculoMulta.CalcularMultaEJuros(contaDto);

        var multaEsperada = contaDto.ValorOriginal * multa;
        var jurosEsperado = contaDto.ValorOriginal * juros * dias;

        contaDto.Should().NotBeNull();
        contaDto.DiasAtrasados.Should().Be(dias);
        contaDto.RegraCalculo.Should().NotBeNullOrEmpty();
        contaDto.ValorCorrigido.Should().Be(contaDto.ValorOriginal + multaEsperada + jurosEsperado);
    }
}
