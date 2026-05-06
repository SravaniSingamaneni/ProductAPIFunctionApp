using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker;
using Azure.Messaging.ServiceBus;

namespace ProductAPIFunctionApp.Services
{
    public class DeadLetterQueue_ProductFunction
    {
        private readonly ILogger<DeadLetterQueue_ProductFunction> _logger;

        public DeadLetterQueue_ProductFunction(ILogger<DeadLetterQueue_ProductFunction> logger)
        {
            _logger = logger;
        }

        [Function("SaveProductDLQ")]
        public async Task Run(
            [ServiceBusTrigger("product-queue/$DeadLetterQueue",
            Connection ="ServiceBusConnection")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            var reqBody=Encoding.UTF8.GetString(message.Body);

            _logger.LogError("===== DLQ MESSAGE RECEIVED =====");
            _logger.LogError($"DLQ Message: {reqBody}");
            _logger.LogError($"Reason: {message.DeadLetterReason}");
            _logger.LogError($"Error: {message.DeadLetterErrorDescription}");

            // Mark as completed after logging
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
