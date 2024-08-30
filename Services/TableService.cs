using Azure.Data.Tables;
using CLDV6212POE.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CLDV6212POE.Services
{
    // TableService handles operations related to Azure Table Storage
    public class TableService
    {
        private readonly TableClient _tableClient;

        // Constructor initializes the TableClient using the connection string from configuration
        public TableService(IConfiguration configuration)
        {
            var connectionString = configuration["AzureStorage:ConnectionString"]; // Get the connection string from configuration
            var serviceClient = new TableServiceClient(connectionString); // Create the TableServiceClient
            _tableClient = serviceClient.GetTableClient("CustomerProfiles"); // Get the table client for the "CustomerProfiles" table
            _tableClient.CreateIfNotExists(); // Create the table if it doesn't exist
        }

        // Method to add a customer profile entity to the Azure Table Storage
        public async Task AddEntityAsync(CustomerProfile profile)
        {
            await _tableClient.AddEntityAsync(profile); // Add the entity to the table
        }
    }
}
