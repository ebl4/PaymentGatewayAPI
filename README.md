# PaymentGatewayAPI

Projeto de exemplo para processar pagamentos via um serviço HTTP (simula integração com um PSP).

Resumo rápido
- Projeto principal: PaymentGatewayAPI (ASP.NET Minimal/Controller API)
- Projeto de testes: PaymentGatewayAPI.Tests (xUnit)
- Alvo de framework: .NET 10 (net10.0)

Pré-requisitos
- .NET 10 SDK instalado
- Visual Studio 2026 ou CLI dotnet

Como compilar
- Na raiz do repositório:
  dotnet build PaymentGatewayAPI.slnx

Como executar a API localmente
- Usando CLI:
  dotnet run --project PaymentGatewayAPI/PaymentGatewayAPI.csproj
- A API expõe o controller:
  POST /Payment
  Corpo: { "value": decimal, "currency": string, "description": string }
  Resposta: PaymentResponseDTO { PaymentId, Status, Message }

Configuração e comportamento
- O serviço de pagamento (PaymentService) recebe um HttpClient via DI. Configure o BaseAddress do HttpClient no Startup/Program (veja PspExtensions.cs).
- PaymentService envia um FormUrlEncodedContent para o endpoint "charges" com os campos: amount (em centavos), currency, source (tok_visa usado no teste) e description.
- Em caso de sucesso HTTP retorna PaymentResponseDTO(PaymentId=1, Status="Ok", Message=conteúdo JSON);
- Em caso de falha HTTP retorna PaymentResponseDTO(PaymentId=0, Status="Falha no teste", Message=erro).

Como executar testes
- Na raiz do repositório:
  dotnet test
- Os testes usam um HttpMessageHandler mock para simular respostas do provedor e validar:
  - Cenário de sucesso (HTTP 200 e payload JSON)
  - Cenário de erro (HTTP 400)

Estrutura de diretórios relevante
- PaymentGatewayAPI/           => Projeto da API
- PaymentGatewayAPI/Controllers => Endpoints (PaymentController)
- PaymentGatewayAPI/Services   => Implementação e interface do serviço de pagamento
- PaymentGatewayAPI.Tests/     => Projeto de testes xUnit

Observações
- Arquivo PaymentGatewayAPI.Tests/PaymentServiceTests.cs contém testes unitários para PaymentService.
