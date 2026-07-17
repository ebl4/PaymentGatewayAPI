using PaymentGatewayAPI.Services;
using PaymentGatewayAPI.Services.Impl;
using System.Net.Http.Headers;

namespace PaymentGatewayAPI.Extensions
{
    public static class PspExtensions
    {
        public static WebApplicationBuilder AddPsp(
            this WebApplicationBuilder builder) 
        {
            var gatewaySettings = builder.Configuration.GetSection("PaymentGateway");

            builder.Services.AddHttpClient<IPaymentService, PaymentService>(client =>
            {
                client.BaseAddress = new Uri(gatewaySettings["BaseUrl"] ?? throw new ArgumentNullException("BaseUrl inválida."));
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("Api_Key"));
            });

            return builder;
        }
    }
}
