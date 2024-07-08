using System.Diagnostics.CodeAnalysis;
using ApiConta.Domain.Dto;
using ApiConta.Domain.Entities;
using AutoMapper;

namespace ApiConta.Infra.Perfil;

[ExcludeFromCodeCoverage]
public class ContaRepositoryProfile : Profile
{
    public ContaRepositoryProfile()
    {
        CreateMap<ContaDto, ContaEntity>()
            .ForMember(e => e.IdConta, opt => opt.MapFrom(e => Guid.NewGuid()));

        CreateMap<ContaEntity, ContaDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(e => e.IdConta));
    }
}
