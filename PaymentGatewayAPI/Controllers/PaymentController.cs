using Microsoft.AspNetCore.Mvc;
using PaymentGatewayAPI.Services;
using static PaymentGatewayAPI.Data.DTO.CreatePaymentDTO;

namespace PaymentGatewayAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController(
        IPaymentService paymentService, 
        ILogger<PaymentController> logger
        ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequestDTO request)
        {
            logger.LogInformation("Iniciando processamento de pagamento...");
            var response = await paymentService.ProcessPaymentAsync(request);
            
            if (response is null)
            {
                logger.LogError("Erro ao processar o pagamento");
                return BadRequest("An error occurred while processing the payment.");
            }
                
            logger.LogInformation("Pagamento processado com sucesso");
            return Ok(response);
        }
    }
}
