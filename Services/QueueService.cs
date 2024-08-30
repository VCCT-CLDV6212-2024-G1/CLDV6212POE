using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CLDV6212POE.Services
{
    // QueueService handles operations related to Azure Queue Storage
    public class QueueService
    {
        private readonly QueueServiceClient _queueServiceClient;

        // Constructor initialises the QueueServiceClient using the connection string from configuration
        public QueueService(IConfiguration configuration)
        {
            _queueServiceClient = new QueueServiceClient(configuration["AzureStorage:ConnectionString"]);
        }

        // Method to send a message to a specified queue in Azure Queue Storage
        public async Task SendMessageAsync(string queueName, string message)
        {
            var queueClient = _queueServiceClient.GetQueueClient(queueName); // Get the queue client
            await queueClient.CreateIfNotExistsAsync(); // Create the queue if it doesn't exist
            await queueClient.SendMessageAsync(message); // Send the message to the queue
        }
    }
}