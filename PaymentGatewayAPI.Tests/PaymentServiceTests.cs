using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using PaymentGatewayAPI.Services.Impl;
using static PaymentGatewayAPI.Data.DTO.CreatePaymentDTO;

namespace PaymentGatewayAPI.Tests
{
    internal class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _responder;
        public HttpRequestMessage? LastRequest { get; private set; }

        public MockHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responder)
        {
            _responder = responder;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LastRequest = request;
            return Task.FromResult(_responder(request));
        }
    }

    public class PaymentServiceTests
    {
        [Fact]
        public async Task ProcessPaymentAsync_ReturnsSuccess_WhenApiReturnsSuccess()
        {
            var expectedContent = "{\"id\":\"ch_test\"}";
            var handler = new MockHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedContent)
            });

            var client = new HttpClient(handler) { BaseAddress = new Uri("https://api.test/") };
            var service = new PaymentService(client);

            var request = new PaymentRequestDTO(20m, "brl", "Teste");
            var result = await service.ProcessPaymentAsync(request);

            Assert.NotNull(result);
            Assert.Equal(1, result.PaymentId);
            Assert.Equal("Ok", result.Status);
            Assert.Equal(expectedContent, result.Message);

            // Verifica que o campo amount foi enviado em centavos (20,00 -> 2000)
            var content = await handler.LastRequest!.Content.ReadAsStringAsync();
            Assert.Contains("amount=2000", content);
            Assert.Contains("currency=brl", content);
            Assert.Contains("description=Teste", content);
        }

        [Fact]
        public async Task ProcessPaymentAsync_ReturnsFailure_WhenApiReturnsError()
        {
            var error = "Bad Request";
            var handler = new MockHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(error)
            });

            var client = new HttpClient(handler) { BaseAddress = new Uri("https://api.test/") };
            var service = new PaymentService(client);

            var request = new PaymentRequestDTO(15.5m, "brl", "Teste Falha");
            var result = await service.ProcessPaymentAsync(request);

            Assert.NotNull(result);
            Assert.Equal(0, result.PaymentId);
            Assert.Equal("Falha no teste", result.Status);
            Assert.Equal(error, result.Message);
        }
    }
}
