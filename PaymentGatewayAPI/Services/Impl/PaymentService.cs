using static PaymentGatewayAPI.Data.DTO.CreatePaymentDTO;

namespace PaymentGatewayAPI.Services.Impl
{
    public class PaymentService(HttpClient httpClient) : IPaymentService
    {
        public async Task<PaymentResponseDTO?> ProcessPaymentAsync(PaymentRequestDTO request)
        {
            // Cartão de teste padrão do Stripe que sempre aprova: 4242 4242 4242 4242
            var dadosDoPagamento = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("amount", ((int)(request.Value * 100)).ToString()), // R$ 20,00 (Stripe usa centavos)
                new KeyValuePair<string, string>("currency", request.Currency),
                new KeyValuePair<string, string>("source", "tok_visa"), // Token de teste do Stripe
                new KeyValuePair<string, string>("description", request.Description)
            });

            var response = await httpClient.PostAsync("charges", dadosDoPagamento);

            if (response.IsSuccessStatusCode)
            {
                var jsonResultado = await response.Content.ReadAsStringAsync();
                var resultado = new PaymentResponseDTO(1, "Ok", jsonResultado);

                return resultado;
            }

            var erro = await response.Content.ReadAsStringAsync();
            return new PaymentResponseDTO(0, "Falha no teste", erro);
        }
    }
}
