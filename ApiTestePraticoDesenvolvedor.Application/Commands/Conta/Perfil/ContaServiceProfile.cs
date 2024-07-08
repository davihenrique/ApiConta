using ApiConta.Application.Commands.Conta.Requests;
using ApiConta.Application.Commands.Conta.Responses;
using ApiConta.Domain.Dto;
using AutoMapper;

namespace ApiConta.Application.Commands.Conta.Perfil;
public class ContaServiceProfile : Profile
{
    public ContaServiceProfile()
    {
        CreateMap<ContaIncluirRequest, ContaDto>();

        CreateMap<ContaDto, ContaListagemResponse>()
            .ForMember(r => r.QuantidadeDiasDeAtraso, opt => opt.MapFrom(dto => dto.DiasAtrasados));
    }
}
