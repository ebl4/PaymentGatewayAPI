using static PaymentGatewayAPI.Data.DTO.CreatePaymentDTO;

namespace PaymentGatewayAPI.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponseDTO?> ProcessPaymentAsync(PaymentRequestDTO request);
    }
}
