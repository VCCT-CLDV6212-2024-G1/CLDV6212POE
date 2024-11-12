using Azure.Storage.Files.Shares;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace CLDV6212POE.Services
{
    // FileService handles operations related to Azure File Storage
    public class FileService
    {
        private readonly ShareServiceClient _shareServiceClient;

        
        public FileService(IConfiguration configuration)
        {
            _shareServiceClient = new ShareServiceClient(configuration["AzureStorage:ConnectionString"]);// Constructor initialises the ShareServiceClient using the connection string from configuration
        }

        // Method to upload a file to a specified share in Azure File Storage
        public async Task UploadFileAsync(string shareName, string fileName, Stream content)
        {
            var shareClient = _shareServiceClient.GetShareClient(shareName); // Get the share client.
            await shareClient.CreateIfNotExistsAsync(); // Create the share if it doesn't exist.
            var directoryClient = shareClient.GetRootDirectoryClient(); // Get the root directory client.
            var fileClient = directoryClient.GetFileClient(fileName); // Get the file client for the specific file.
            await fileClient.CreateAsync(content.Length); // Create the file with the specified length
            await fileClient.UploadAsync(content); // Upload the file content
        }
    }
}
