<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MixologyMatrix.MVC.Data;

>>>>>>> e5493e86dcf31e4bc15856a8cdb7116a7cd7ae0a
namespace MixologyMatrix.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
<<<<<<< HEAD
=======
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
>>>>>>> e5493e86dcf31e4bc15856a8cdb7116a7cd7ae0a
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
<<<<<<< HEAD
            if (!app.Environment.IsDevelopment())
=======
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
>>>>>>> e5493e86dcf31e4bc15856a8cdb7116a7cd7ae0a
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
<<<<<<< HEAD
=======
            app.MapRazorPages();
>>>>>>> e5493e86dcf31e4bc15856a8cdb7116a7cd7ae0a

            app.Run();
        }
    }
}
