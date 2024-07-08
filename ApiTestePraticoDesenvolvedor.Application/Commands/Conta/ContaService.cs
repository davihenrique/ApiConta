using ApiConta.Application.Commands.Conta.Enum;
using ApiConta.Application.Commands.Conta.Requests;
using ApiConta.Application.Commands.Conta.Responses;
using ApiConta.Application.Extensions;
using ApiConta.Application.Interfaces.Conta;
using ApiConta.Domain.Dto;
using ApiConta.Infra.Interfaces;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace ApiConta.Application.Commands.Conta;
public class ContaService(IContaRepository contaRepository, IMapper mapper) : IContaService
{
    private readonly IContaRepository _contaRepository = contaRepository;
    private readonly IMapper _mapper = mapper;
    public ContaIncluirResponse Incluir(ContaIncluirRequest request)
    {
        var pagamentoValido = _contaRepository
            .VerificaPagamento(request.DataPagamento);

        if (!pagamentoValido)
        {
            return new ContaIncluirResponse
            {
                Status = StatusConta.ProblemaAoIncluir,
                Mensagens = ["Problema ao Incluir a Conta.",
                              $"Já Existe Um Pagamento Com a Data {request.DataPagamento} !"]
            };
        }

        var contaDto = _mapper.Map<ContaDto>(request);

        contaDto.CalcularMultaEJuros();

        var result = _contaRepository.CadastrarConta(contaDto);

        if (result == Guid.Empty)
        {
            return new ContaIncluirResponse
            {
                Status = StatusConta.ProblemaAoIncluir,
                Mensagens = ["Problema ao Incluir a Conta.",
                              "Conta não Inclusa!"]
            };
        }

        return new ContaIncluirResponse
        {
            Status = StatusConta.ContaIncluida,
            Id = result,
            Mensagens = ["Conta Incluída Com Sucesso."]
        };
    }

    public IEnumerable<ContaListagemResponse> Listar(string? idConta)
    {
        IList<ContaDto> contas = [];

        if (!idConta.IsNullOrEmpty())
        {
            if (Guid.TryParse(idConta, out var idContaGuid))
            {
                var resultadoconta = _contaRepository.PesquisarConta(idContaGuid);
                if (resultadoconta != null)
                {
                    contas.Add(resultadoconta);
                }
            }
        }
        else
        {
            var resultadoContas = _contaRepository.ListaContasCadastradas();
            contas = _mapper.Map<IList<ContaDto>>(resultadoContas);
        }

        return _mapper.Map<IEnumerable<ContaListagemResponse>>(contas);
    }
}
