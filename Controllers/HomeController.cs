using Microsoft.AspNetCore.Mvc;
using CLDV6212POE.Models;
using CLDV6212POE.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Data.SqlClient;


namespace CLDV6212POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly CustomerService _customerService; // Inject CustomerService
        private readonly BlobService _blobService; // Inject BlobService

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger, IConfiguration configuration, CustomerService customerService, BlobService blobService)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
            _customerService = customerService;
            _blobService = blobService;
        }


        public IActionResult Index()
        {
            var model = new CustomerProfile();
            return View(model);
        }

       
        [HttpPost]
        public async Task<IActionResult> StoreTableInfo(CustomerProfile profile) // store customer info in Table
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Call Azure function to store data in Azure Table
                    using var httpClient = _httpClientFactory.CreateClient();
                    var baseUrl = _configuration["AzureFunctions:StoreTableInfo"];
                    var requestUri = $"{baseUrl}&tableName=CustomerProfiles&partitionKey={profile.PartitionKey}&rowKey={profile.RowKey}&firstName={profile.FirstName}&lastName={profile.LastName}&phoneNumber={profile.PhoneNumber}&Email={profile.Email}";

                    var response = await httpClient.PostAsync(requestUri, null);

                    if (response.IsSuccessStatusCode)
                    {
                        // Insert customer data into SQL database
                        await _customerService.InsertCustomerAsync(profile);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error submitting client info: {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred while submitting client info: {ex.Message}");
                }
            }

            return View("Index", profile);
        }

        // Existing method to upload blob and new SQL insertion for blob data
        [HttpPost]
        public async Task<IActionResult> UploadBlob(IFormFile imageFile)
        {
            if (imageFile != null)
            {
                try
                {
                    // Call Azure function to upload the blob
                    using var httpClient = _httpClientFactory.CreateClient();
                    using var stream = imageFile.OpenReadStream();
                    var content = new StreamContent(stream);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imageFile.ContentType);

                    var baseUrl = _configuration["AzureFunctions:UploadBlob"];
                    string url = $"{baseUrl}&blobName={imageFile.FileName}";
                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Convert image to byte array for SQL insertion
                        using (var memoryStream = new MemoryStream())
                        {
                            await imageFile.CopyToAsync(memoryStream);
                            var imageData = memoryStream.ToArray();

                            // Insert image data into SQL BlobTable
                            await _blobService.InsertBlobAsync(imageData);
                        }

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error submitting image: {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred while submitting image: {ex.Message}");
                }
            }
            else
            {
                _logger.LogError("No image file provided.");
            }

            return View("Index");
        }
    }
}

