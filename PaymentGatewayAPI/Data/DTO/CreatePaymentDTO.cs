namespace PaymentGatewayAPI.Data.DTO
{
    public class CreatePaymentDTO
    {
        public record PaymentRequestDTO(decimal Value, string Currency, string Description);
        public record PaymentResponseDTO(int PaymentId, string Status, string Message);
    }
}
