﻿using ApiConta.Domain.Dto;

namespace ApiConta.Infra.Interfaces;
public interface IContaRepository
{
    public Guid CadastrarConta(ContaDto contadto);
    public IEnumerable<ContaDto> ListaContasCadastradas();
    public ContaDto? PesquisarConta(Guid id);
}
