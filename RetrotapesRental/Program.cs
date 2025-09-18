using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Retrotapes.DAL.Data;
using Retrotapes.DAL.Models;
using Retrotapes.DAL.Repositories;
using Retrotapes.DAL.Seeder;
using Retrotapes.DAL.Services;


namespace RetrotapesRental
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            var sakilaDataBase = builder.Configuration.GetConnectionString("SakilaDataBase")
                ?? throw new InvalidOperationException("Connection string 'SakilaDataBase' not found.");

            // Identity / ASP.NET internal stuff
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(defaultConnection));

            // Sakila database
            builder.Services.AddDbContext<SakilaDbContext>(options =>
                options.UseSqlServer(sakilaDataBase));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders(); 

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            //Add Repositories
            builder.Services.AddScoped<IActorRepository, ActorRepository>();
            builder.Services.AddScoped<IFilmRepository, FilmRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

            // Add EmailSender service
            builder.Services.AddTransient<IEmailSender, EmailSender>();



            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Get RoleManager and UserManager
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var sakilaContext = services.GetRequiredService<SakilaDbContext>();

                // Seed roles
                await RoleSeeder.SeedRolesAsync(roleManager);


                
                var sakilaStaffList = await sakilaContext.staff
                    .Select(s => new Staff
                    {
                        Email = s.Email
                      
                    })
                    .ToListAsync();

                
                await RoleSeeder.SyncSakilaStaffToIdentity(userManager, sakilaStaffList);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
