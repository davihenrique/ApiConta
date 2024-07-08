using ApiConta.Application.Commands.Conta;
using ApiConta.Application.Commands.Conta.Perfil;
using ApiConta.Application.Commands.Conta.Responses;
using ApiConta.Domain.Dto;
using ApiConta.Infra.Interfaces;
using ApiConta.Tests.SharedKernel.Mock.Domain.Dto;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace ApiConta.Tests.Application.Commands.Conta;
public class ContaServiceListarTests
{
    private readonly Mock<IContaRepository> _contaRepository;
    private readonly IMapper _mapper;

    public ContaServiceListarTests()
    {
        _contaRepository = new Mock<IContaRepository>();

        var config = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new ContaServiceProfile());
        });

        _mapper = config.CreateMapper();
    }

    [Fact(DisplayName = "Deve Listar Contas")]
    public void DeveListarContas()
    {

        var retorno = ContaDtoMock.ContasListagem();
        var esperado = _mapper.Map<IEnumerable<ContaListagemResponse>>(retorno);

        _contaRepository.Setup(r => r.ListaContasCadastradas()).Returns(retorno);
        var contaService = new ContaService(_contaRepository.Object, _mapper);

        var result = contaService.Listar(null);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(esperado);
    }

    [Fact(DisplayName = "Deve Listar Uma Conta")]
    public void DevePesquisarUmaConta()
    {
        var id = Guid.NewGuid().ToString();
        var retorno = ContaDtoMock.Conta();

        var esperado = _mapper.Map<IEnumerable<ContaListagemResponse>>(new List<ContaDto> { retorno });

        _contaRepository.Setup(r => r.PesquisarConta(It.IsAny<Guid>())).Returns(retorno);
        var contaService = new ContaService(_contaRepository.Object, _mapper);

        var result = contaService.Listar(id);

        result.Should().NotBeNull();
        result.FirstOrDefault().Should().BeEquivalentTo(esperado.FirstOrDefault());
    }
}
