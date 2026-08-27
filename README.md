# PaymentGatewayAPI

Description
-----------
PaymentGatewayAPI is a sample web API for payment processing that simulates integration with a Payment Service Provider (PSP). The project demonstrates a basic flow for creating and querying transactions, separation of concerns (controllers, services, tests), and how to test HTTP integrations using mocks. This example uses the Stripe API as the PSP.

Tech stack
----------
- .NET 10 (net10.0)
- ASP.NET Core Web API
- xUnit (test project)

Quick summary
-------------
- Main project: PaymentGatewayAPI
- Test project: PaymentGatewayAPI.Tests

Prerequisites
-------------
- .NET 10 SDK: https://dotnet.microsoft.com/
- Visual Studio 2026 or dotnet CLI

Build
-----
From the repository root:

   dotnet build PaymentGatewayAPI.slnx

Run locally
-----------
Using the CLI:

   dotnet run --project PaymentGatewayAPI/PaymentGatewayAPI.csproj

Or open `PaymentGatewayAPI.slnx` in Visual Studio and run the project in debug mode.

Sample endpoints
----------------
- POST /Payment — create a new transaction (body: value, currency, description)
- GET /Payment/{id} — get transaction status/details
- GET /health — health check

Configuration
-------------
Main configuration is in `appsettings.json`. Environment variables can override important keys. Examples:

- ConnectionStrings: database connection string (if applicable)
- PaymentGateway:ApiKey — API key for PSP integration (e.g., Stripe)
- ASPNETCORE_ENVIRONMENT — Development/Production

Payment service behavior
------------------------
The PaymentService uses an HttpClient (injected via DI) to call the PSP. In tests, this HttpClient is mocked using a custom HttpMessageHandler to simulate success and error responses.

Tests
-----
Run tests with:

   dotnet test

Contributing
------------
Pull requests are welcome. Open issues to discuss larger changes before implementing.

License
-------
Check the LICENSE file at the repository root. If missing, contact the project maintainers.


Portuguese
-------
Descrição
---------
PaymentGatewayAPI é uma API web de exemplo para processamento de pagamentos que simula a integração com um Provedor de Serviços de Pagamento (PSP). O objetivo do projeto é demonstrar um fluxo básico de criação e consulta de transações, separação de responsabilidades (controller, serviços, testes) e como testar integrações HTTP usando mocks. Este exemplo usa a API do Stripe como PSP.

Stack técnica
-------------
- .NET 10 (net10.0)
- ASP.NET Core Web API
- xUnit (projeto de testes)

Resumo rápido
-------------
- Projeto principal: PaymentGatewayAPI
- Projeto de testes: PaymentGatewayAPI.Tests

Pré-requisitos
--------------
- .NET 10 SDK instalado: https://dotnet.microsoft.com/
- Visual Studio 2026 ou CLI dotnet

Como compilar
-------------
Na raiz do repositório:

   dotnet build PaymentGatewayAPI.slnx

Como executar localmente
------------------------
Usando a CLI:

   dotnet run --project PaymentGatewayAPI/PaymentGatewayAPI.csproj

Ou abra a solução `PaymentGatewayAPI.slnx` no Visual Studio e execute em modo de depuração.

Endpoints (exemplos)
--------------------
- POST /Payment — cria uma nova transação (corpo: value, currency, description)
- GET /Payment/{id} — obtém status/detalhes de uma transação
- GET /health — verificação de integridade

Configuração
-------------
A configuração principal está em `appsettings.json`. Variáveis de ambiente podem sobrescrever chaves importantes. Exemplos:

- ConnectionStrings: cadeia de conexão do banco (se aplicável)
- PaymentGateway:ApiKey — chave para integração com PSP (Ex.: Stripe)
- ASPNETCORE_ENVIRONMENT — Development/Production

Comportamento do serviço de pagamento
------------------------------------
O PaymentService utiliza um HttpClient (injetado via DI) para chamar o PSP. Em testes esse HttpClient é mockado através de um HttpMessageHandler personalizado para simular respostas de sucesso e erro.

Testes
------
Execute os testes com:

   dotnet test

Contribuição
------------
Pull requests são bem-vindos. Abra issues para discutir mudanças ou problemas maiores antes de implementar.

Licença
-------
Verifique o arquivo LICENSE na raiz do repositório. Caso não exista, consulte os mantenedores do projeto.

Estrutura de diretórios relevante
- PaymentGatewayAPI/           => Projeto da API
- PaymentGatewayAPI/Controllers => Endpoints (PaymentController)
- PaymentGatewayAPI/Services   => Implementação e interface do serviço de pagamento
- PaymentGatewayAPI.Tests/     => Projeto de testes xUnit

Observações
- Arquivo PaymentGatewayAPI.Tests/PaymentServiceTests.cs contém testes unitários para PaymentService.
