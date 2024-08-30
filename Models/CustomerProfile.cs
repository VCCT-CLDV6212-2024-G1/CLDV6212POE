using Azure;
using Azure.Data.Tables;
using System;

namespace CLDV6212POE.Models
{
    // CustomerProfile represents a customer's profile entity for Azure Table Storage.
    public class CustomerProfile : ITableEntity
    {
        public string PartitionKey { get; set; } // PartitionKey for grouping related entities
        public string RowKey { get; set; } // RowKey is the unique identifier for the entity
        public DateTimeOffset? Timestamp { get; set; } // Timestamp for tracking the entity's last modification
        public ETag ETag { get; set; } // ETag for concurrency control

        // Additional properties for the customer profile
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor to initialise the PartitionKey and generate a unique RowKey
        public CustomerProfile()
        {
            PartitionKey = "CustomerProfile";
            RowKey = Guid.NewGuid().ToString();
        }
    }
}
