using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using W8BookTest.Data;
using W8BookTest.Repositories;
namespace W8BookTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<W8BookTestContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("W8BookTestContext") ?? throw new InvalidOperationException("Connection string 'W8BookTestContext' not found.")));
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
