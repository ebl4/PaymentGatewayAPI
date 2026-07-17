using Serilog;

namespace PaymentGatewayAPI.Extensions
{
    public static class SerilogExtensions
    {
        public static WebApplicationBuilder AddSerilog(
            this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Host.UseSerilog(Log.Logger, true);
            return builder;
        }
    }
}
