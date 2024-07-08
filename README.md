
# ApiTestePraticoDesenvolvedor

## Observações
Essa aplicação foi criada anteriormente em outra conta minha do GitHub.  
Github Actions Foram Removidas.

## Solution:

 __1 - API__:  
Contém a Aplicação com os Controllers.

 __2 - Application__:  
Contém os Serviços.

__3 - Infrastructure__:  
Contém Migration, Repositorios e o DatabaseContext.

__4 - Domain__:  
Contém Entities e DTOs.

__5 - Tests__:  
Contém os Projetos referente aos Teste de Unidade.

 ![image info](./docs/img/solution.png)

## Postman Collections:
Collection do Postman para auxiliar os testes:

[Ir para a Collection](./docs/ApiConta.postman_collection.json)

_A API retornar os Erros com Código 422_

## Pacotes Nugets Utilizados:

### AutoMapper
![image info](./docs/img/pacotes/automapper.png)

Pacote Nuget utilizado para fazer mapeamento de objetos.  
Utilizado para deixar o código mais limpo e facilitar o mapeamento de objetos.

## FluentValidation

![image info](./docs/img/pacotes/fluentvalidation.png)

Pacote Nuget utilizado para fazer validações de objetos.  
Utilizado para validar o corpo das requisições.  

## Entity Framework Core
![image info](./docs/img/pacotes/ef-core.png)

Biblioteca de mapeamento objeto-relacional (ORM).  
Utilizado para fazer a abordagem "Code First".

## Scrutor
![image info](./docs/img/pacotes/scrutor.png)  
Pacote Nuget utilizado para realizar a injeção de dependência.  


## coverlet.collector
![image info](./docs/img/pacotes/coverlet.collector.png)  
Pacote Nuget utilizado  para medir cobertura de testes.


## FluentAssertions
![image info](./docs/img/pacotes/fluentassertions.png)  
Pacote Nuget com conjunto de métodos que permitem especificar de forma mais natural o resultado esperado de testes de unidade.

## xunit
![image info](./docs/img/pacotes/xunit.png)  
Pacote Nuget para Testes de Unidade.