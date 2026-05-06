using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ProductAPIFunctionApp.Models;
using ProductAPIFunctionApp.Services;
using System.Text;
using System.Text.Json;

namespace ProductAPIFunctionApp.Functions
{
    public class SaveProduct
    {
        private readonly IProductService _service;
        private readonly ILogger<SaveProduct> _logger;

        public SaveProduct(IProductService service, ILogger<SaveProduct> logger)
        {
            _service = service;
            _logger = logger;
        }

        [Function("SaveProduct")]
        public async Task Run(
            [ServiceBusTrigger("product-queue", Connection ="ServiceBusConnection")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            try
            {
                var reqBody = Encoding.UTF8.GetString(message.Body);
                _logger.LogInformation($"Received message: {reqBody}");

                var productMessage = JsonSerializer.Deserialize<ProductMessage>(reqBody);
                if(productMessage == null)
                {
                    throw new Exception("Invalid message format - deserialization failed.");
                }
                //calling the service class to create/delete the product
                await _service.HandleMessageAsync(productMessage);

                //Success
                await messageActions.CompleteMessageAsync(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Processing Failed for message: {message}");

                //Send to DLQ
                await messageActions.DeadLetterMessageAsync(
                   message,
                   deadLetterReason:ex.GetType().Name,
                   deadLetterErrorDescription: ex.Message);
            }
        }
    }
}
