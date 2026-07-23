# PaymentGatewayAPI.Tests

Descrição
- Projeto de testes unitários (xUnit) para PaymentGatewayAPI.

O que está coberto
- Testes para PaymentService (PaymentServiceTests.cs):
  - ProcessPaymentAsync_ReturnsSuccess_WhenApiReturnsSuccess
  - ProcessPaymentAsync_ReturnsFailure_WhenApiReturnsError

Como funcionam os testes
- Os testes criam um HttpClient customizado com um HttpMessageHandler falso (MockHttpMessageHandler) que devolve respostas HTTP controladas.
- Valida-se tanto o objeto retornado pelo serviço quanto o conteúdo enviado no corpo (amount em centavos, currency, description).

Executando os testes
- Na raiz do repositório ou no diretório do projeto de testes:
  dotnet test

Adicionar novos testes
- Para testar outros cenários de PaymentService, acrescente métodos no arquivo PaymentServiceTests.cs seguindo a mesma estratégia de mock do HttpMessageHandler.
