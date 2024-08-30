using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace CLDV6212POE.Services
{
    // BlobService handles operations related to Azure Blob Storage
    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        // Constructor initialises the BlobServiceClient using the connection string from configuration
        public BlobService(IConfiguration configuration)
        {
            _blobServiceClient = new BlobServiceClient(configuration["AzureStorage:ConnectionString"]);
        }

        // Method to upload a blob (file) to a specified container in Azure Blob Storage
        public async Task UploadBlobAsync(string containerName, string blobName, Stream content)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName); // Get the container client
            await containerClient.CreateIfNotExistsAsync(); // Create the container if it doesn't exist
            var blobClient = containerClient.GetBlobClient(blobName); // Get the blob client for the specific file
            await blobClient.UploadAsync(content, true); // Upload the file content, overwrite if it exists
        }
    }
}
