using CLDV6212POE.Services;

//References: 
// https://learn.microsoft.com/en-us/azure/storage/common/storage-analytics-logging
//https://stackoverflow.com/questions/77450221/how-to-retrieve-logging-config-in-azure-storage-blob-queue-and-table-service-wi
// https://www.site24x7.com/learn/azure-storage-types.html
// https://docs.dynatrace.com/docs/setup-and-configuration/setup-on-cloud-platforms/microsoft-azure-services/azure-integrations/azure-cloud-services-metrics/monitor-azure-storage-account
// https://www.azadvertizer.net/azpolicyadvertizer/storage_deploy-storage-monitoring-log-analytics.html

namespace CLDV6212POE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register your services here
            builder.Services.AddSingleton<BlobService>();
            builder.Services.AddSingleton<FileService>();
            builder.Services.AddSingleton<QueueService>();
            builder.Services.AddSingleton<TableService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Set up the default route for the application
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();  // Run the application

        }
    }
}
//