using CLDV6212POE.Services;

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
