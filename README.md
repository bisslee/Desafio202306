# Desafio202306
Desafio Técnico Carrefour 

﻿# CashFlow

## Descrição do Projeto
O CashFlow é um aplicativo para controlar o fluxo de caixa diário de um comerciante, registrando lançamentos de débito e crédito e fornecendo um saldo consolidado diário.

## Estrutura do Projeto
O projeto foi desenvolvido utilizando a arquitetura DDD (Domain Driven Design) e separado em camadas, sendo elas:
```bash
CashFlow (Solution)
├── CashFlow.Api
│   ├── Controllers
│   ├── Models
│   └── Mapping
├── CashFlow.Domain
│   └── Models
│
├── CashFlow.Service
│   ├── Interface
│   └── Services
│
├── CashFlow.Infrastructure
│   ├── Data
│   │   └── Contexts
│   ├── Migrations
│   └── Repositories
│
└── CashFlow.Tests
    └── Unit
    
```

## Instruções de Instalação e Execução

### Pré-requisitos
- .NET Core 6 SDK
- SQL Server
- Docker (opcional)

### Configuração do Banco de Dados
- Crie um banco de dados no SQL Server para o CashFlow.
- Ajuste a string de conexão no arquivo `appsettings.json` do projeto CashFlow.Api.

### Executando as Migrações Externamente
1. Certifique-se de que você tenha o SDK do .NET Core 6 instalado em seu ambiente de desenvolvimento.
2. Abra o terminal ou prompt de comando e navegue até o diretório raiz do projeto CashFlow.Infrastructure.
3 . Execute o seguinte comando para aplicar as migrações no banco de dados:

```bash
dotnet ef migrations add InitialStructure --project CashFlow.Infrastructure
```

### Executando Localmente
1. Navegue até a pasta do projeto CashFlow.Api.
2. Execute o seguinte comando no terminal para iniciar a aplicação:

```bash
dotnet run
```
3. Acesse a API através do endereço `http://localhost:5000`.

### Executando em um Contêiner Docker
1. Navegue até a pasta do projeto CashFlow.Api.
2. Crie a imagem Docker usando o seguinte comando:

```bash
docker build -t cashflow-api .
```
3. Execute o seguinte comando para iniciar o contêiner:

```bash
docker run -d -p 5000:80 --name cashflow-api cashflow-api
```
4. Acesse a API através do endereço `http://localhost:5000`.

### Executando os Testes
1. Navegue até a pasta do projeto CashFlow.Tests.
2. Execute o seguinte comando no terminal para executar os testes:

```bash
dotnet test
```

## Detalhes e Instruções de Utilização dos Serviços
A API do CashFlow possui os seguintes endpoints:

- `GET /api/transactions`: Retorna a lista de transações registradas.
- `GET /api/transactions/{id}`: Retorna os detalhes de uma transação específica.
- `POST /api/transactions`: Registra uma nova transação.
- `PUT /api/transactions/{id}`: Atualiza os dados de uma transação existente.
- `DELETE /api/transactions/{id}`: Exclui uma transação.

- `GET /api/balance`: Retorna o saldo consolidado atual.

Consulte a documentação da API para obter mais detalhes sobre o uso dos endpoints e os formatos de dados esperados.

---

Essa é uma versão atualizada do arquivo README.md, incluindo instruções detalhadas de instalação, tanto em um servidor local como em um contêiner Docker.

Certifique-se de ajustar as instruções e adicionar mais detalhes relevantes, se necessário, de acordo com as necessidades específicas do seu projeto.

Se você tiver mais dúvidas ou precisar de mais assistência, estou à disposição para ajudar.

Obrigado pela atenção e pela oportunidade!


## Recursos Planejados
Pesquisa por data: Adicionar a capacidade de pesquisar transações com base em uma faixa de datas específica.
Saldo de intervalo: Implementar a funcionalidade de calcular o saldo em um intervalo personalizado de datas.
Múltiplos clientes com login e senha: Permitir que vários clientes se registrem e acessem o sistema usando credenciais exclusivas.
Administrador para validar as transações: Introduzir um papel de administrador para validar e aprovar as transações antes de serem consolidadas no saldo.

## Autor
- **Ivana Santos** - [bisslee](https://github.com/bisslee)
- [email](bisslee@gmail.com)


