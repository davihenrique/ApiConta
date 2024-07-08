using ApiConta.Application.Extensions.Dto;
using ApiConta.Domain.Dto;

namespace ApiConta.Application.Extensions;
public static class CalculoMulta
{
    private static CorrecaoDto CalcularMulta(ContaDto contaDto, int diasCorridos)
    {
        double multa;

        if (diasCorridos <= 3)
        {
            multa = contaDto.ValorOriginal * 0.02;
            return new CorrecaoDto
            {
                Valor = multa,
                Messagem = $"Multa 2%: R$ {multa}."
            };
        }

        if (diasCorridos <= 10)
        {
            multa = contaDto.ValorOriginal * 0.03;
            return new CorrecaoDto
            {
                Valor = multa,
                Messagem = $"Multa 3%: R$ {multa}."
            };
        }

        multa = contaDto.ValorOriginal * 0.05;
        return new CorrecaoDto
        {
            Valor = multa,
            Messagem = $"Multa 5%: R$ {multa}."
        };

    }

    private static CorrecaoDto CalcularJuros(ContaDto contaDto, int diasCorridos)
    {
        double juros;

        if (diasCorridos <= 3)
        {
            juros = contaDto.ValorOriginal * 0.01 * diasCorridos;
            return new CorrecaoDto
            {
                Valor = juros,
                Messagem = $"Juros/dia 0,1%: R$ {juros}."
            };
        }

        if (diasCorridos <= 10)
        {
            juros = contaDto.ValorOriginal * 0.02 * diasCorridos;
            return new CorrecaoDto
            {
                Valor = juros,
                Messagem = $"Juros/dia 0,2%: R$ {juros}."
            };
        }

        juros = contaDto.ValorOriginal * 0.03 * diasCorridos;
        return new CorrecaoDto
        {
            Valor = juros,
            Messagem = $"Juros/dia 0.3%: R$ {juros}."
        };
    }

    public static ContaDto CalcularMultaEJuros(this ContaDto contaDto)
    {
        const int NENHUM_DIA_EM_ATRASSO = 0;

        var diasCorridos = (contaDto.DataPagamento - contaDto.DataVencimento).Days;

        if (diasCorridos <= NENHUM_DIA_EM_ATRASSO)
        {
            contaDto.DiasAtrasados = NENHUM_DIA_EM_ATRASSO;
            contaDto.RegraCalculo = string.Empty;
            contaDto.ValorCorrigido = contaDto.ValorOriginal;
            return contaDto;
        }

        var multa = CalcularMulta(contaDto, diasCorridos);
        var juros = CalcularJuros(contaDto, diasCorridos);

        var multaEjuros = multa.Valor + juros.Valor;

        contaDto.DiasAtrasados = diasCorridos;
        contaDto.RegraCalculo = multa.Messagem + " " + juros.Messagem;
        contaDto.ValorCorrigido = contaDto.ValorOriginal + multaEjuros;

        return contaDto;
    }
}
