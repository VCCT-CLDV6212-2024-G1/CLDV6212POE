
# Azure Storage Solution Web Application

## Project Overview

This web application is developed for ABC Retail to leverage Azure Storage Services, providing scalable, reliable, and cost-effective solutions for managing customer profiles, product information, multimedia content, order processing details, and document storage. The application addresses the challenges of handling real-time event processing, message queuing, and complex data analytics requirements by integrating various Azure Storage options.

### Key Features

- **Azure Table Storage:** Stores customer profiles and product-related information.
- **Azure Blob Storage:** Hosts images and multimedia content.
- **Azure Queue Storage:** Manages order processing and inventory messages.
- **Azure File Storage:** Stores contracts, logs, and other documents.
- **Deployed on Azure App Service:** Ensures the application is accessible online.

## Getting Started

### Prerequisites

- **Azure Account:** An active Azure subscription to set up the necessary storage services.
- **Development Environment:** 
  - Node.js and npm (for a JavaScript-based app).
  - Visual Studio Code or any other preferred IDE.
  - GitHub Account (for version control and source code management).

### Setup Instructions

1. **Clone the Repository:**

   ```bash
   git clone <repository-url>
   cd <repository-folder>
   ```

2. **Install Dependencies:**

   ```bash
   npm install
   ```

3. **Configure Azure Services:**

   - **Azure Table Storage:** Create a storage account and a table for customer profiles and product information.
   - **Azure Blob Storage:** Set up a container to host images and multimedia content.
   - **Azure Queue Storage:** Create queues for order processing and inventory management.
   - **Azure File Storage:** Configure a file share for storing contracts, logs, and other documents.

4. **Set Up Environment Variables:**

   Create a `.env` file in the project root and add your Azure Storage connection strings and other necessary configurations:

   ```env
   AZURE_STORAGE_CONNECTION_STRING=<your-storage-connection-string>
   TABLE_NAME=<your-table-name>
   BLOB_CONTAINER=<your-blob-container-name>
   QUEUE_NAME=<your-queue-name>
   FILE_SHARE_NAME=<your-file-share-name>
   ```

5. **Run the Application:**

   ```bash
   npm start
   ```

   The application will be accessible at `http://localhost:3000`.

6. **Deploy to Azure App Service:**

   - Ensure your application is configured to work in a production environment.
   - Follow the Azure deployment guide to deploy the application on Azure App Service.

## Usage

- **Customer Profiles & Product Information:** Use the web interface to add, view, update, and delete customer profiles and product information stored in Azure Table Storage.
- **Media Content Management:** Upload and manage images and multimedia content using Azure Blob Storage.
- **Order Processing & Inventory Management:** Queue and process messages related to order processing and inventory using Azure Queue Storage.
- **Document Storage:** Upload, retrieve, and manage contracts, logs, and other documents using Azure File Storage.

## Screenshots

Include screenshots of the following:
- Storing information in Azure Table Storage.
- Hosting media content in Azure Blob Storage.
- Using Azure Queue Storage for order processing.
- Storing files in Azure File Storage.
- Deployed application running on Azure App Service.

## Repository Links

- **GitHub Repository:** [Link to your GitHub repository](<repository-url>)
- **Deployed Application URL:** cldv6212poe-st10132915.azurewebsites.net

