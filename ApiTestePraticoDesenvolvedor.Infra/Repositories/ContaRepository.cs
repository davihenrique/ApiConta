using System.Diagnostics.CodeAnalysis;
using ApiConta.Domain.Dto;
using ApiConta.Domain.Entities;
using ApiConta.Infra.DatabaseContext;
using ApiConta.Infra.Interfaces;
using AutoMapper;

namespace ApiConta.Infra.Repositories;

[ExcludeFromCodeCoverage]
public class ContaRepository(Context context, IMapper mapper) : IContaRepository
{
    private readonly Context _context = context;
    private readonly IMapper _mapper = mapper;

    public Guid CadastrarConta(ContaDto contadto)
    {
        var conta = _mapper.Map<ContaEntity>(contadto);

        _context.Conta.Add(conta);
        _context.SaveChanges();

        return conta.IdConta;
    }

    public IEnumerable<ContaDto> ListaContasCadastradas()
    {
        var result = _context.Conta;

        if (!result.Any())
        {
            return [];
        }

        return _mapper.Map<IEnumerable<ContaDto>>(result);

    }

    public ContaDto? PesquisarConta(Guid id)
    {
        var conta = _context.Conta.FirstOrDefault(c => c.IdConta == id);
        return _mapper.Map<ContaDto>(conta);
    }
}
