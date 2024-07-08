using ApiConta.Application.Commands.Conta;
using ApiConta.Application.Commands.Conta.Enum;
using ApiConta.Application.Commands.Conta.Perfil;
using ApiConta.Domain.Dto;
using ApiConta.Infra.Interfaces;
using ApiConta.Tests.SharedKernel.Mock.Application.Commands.Conta.Requests;
using ApiConta.Tests.SharedKernel.Mock.Application.Commands.Conta.Responses;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace ApiConta.Tests.Application.Commands.Conta;
public class ContaServiceIncluirTests
{
    private readonly Mock<IContaRepository> _contaRepository;
    private readonly IMapper _mapper;

    public ContaServiceIncluirTests()
    {
        _contaRepository = new Mock<IContaRepository>();

        var config = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new ContaServiceProfile());
        });

        _mapper = config.CreateMapper();
    }

    [Fact(DisplayName = "Deve Incluir Conta")]
    public void DeveIncluirConta()
    {

        _contaRepository.Setup(r => r.VerificaPagamento(It.IsAny<DateTime>())).Returns(true);
        _contaRepository.Setup(r => r.CadastrarConta(It.IsAny<ContaDto>())).Returns(Guid.NewGuid);

        var contaService = new ContaService(_contaRepository.Object, _mapper);

        var result = contaService.Incluir(ContaIncluirRequestMock.GetMocked());

        result.Should().NotBeNull();

        result.Status.Should().Be(StatusConta.ContaIncluida);
        result.Mensagens.First().Should().BeEquivalentTo("Conta Incluída Com Sucesso.");
    }

    [Fact(DisplayName = "Deve Falhar ao Incluir Conta Ja Existente")]
    public void DeveFalharAoIncluirContaJaExistente()
    {
        var dataPagamento = DateTime.Now;

        var esperado = ContaIncluirResponseMock.ContaIncluirResponsePagamentoJaExistente(dataPagamento);
        var contaRequest = ContaIncluirRequestMock.GetMocked();
        contaRequest.DataPagamento = dataPagamento;

        _contaRepository.Setup(r => r.VerificaPagamento(It.IsAny<DateTime>())).Returns(false);

        var ContaService = new ContaService(_contaRepository.Object, _mapper);

        var result = ContaService.Incluir(contaRequest);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(esperado);
    }

    [Fact(DisplayName = "Deve Falhar ao Incluir Conta Nao Inculsa")]
    public void DeveFalharAoIncluirContaNaoInclusa()
    {
        var esperado = ContaIncluirResponseMock.ContaIncluirResponseFalha();
        var contaRequest = ContaIncluirRequestMock.GetMocked();

        _contaRepository.Setup(r => r.VerificaPagamento(It.IsAny<DateTime>())).Returns(true);
        _contaRepository.Setup(r => r.CadastrarConta(It.IsAny<ContaDto>())).Returns(Guid.Empty);

        var ContaService = new ContaService(_contaRepository.Object, _mapper);

        var result = ContaService.Incluir(contaRequest);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(esperado);
    }
}
