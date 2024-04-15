using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using QuizAppBlazor.Server;
using QuizAppBlazor.Server.Data;
using QuizAppBlazor.Server.Models;
using System.Security.Cryptography.X509Certificates;

namespace QuizAppBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCertificateForwarding(options =>
            {
                options.CertificateHeader = "X-SSL-CERT";

                options.HeaderConverter = headerValue =>
                {
                    X509Certificate2? clientCertificate = null;

                    if (!string.IsNullOrWhiteSpace(headerValue))
                    {
                        clientCertificate = new X509Certificate2(StringToByteArray(headerValue));
                    }

                    return clientCertificate!;

                    static byte[] StringToByteArray(string hex)
                    {
                        var numberChars = hex.Length;
                        var bytes = new byte[numberChars / 2];

                        for (int i = 0; i < numberChars; i += 2)
                        {
                            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                        }

                        return bytes;
                    }
                };
            });

            //builder.Services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //    options.HttpsPort = 5001;
            //});

            //var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            // Add services to the container.
            var connectionString = CString.connectionString ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "BlazorCors",
                    policy =>
                    {
                        //policy.WithOrigins("https://localhost:7021")
                        policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCertificateForwarding();
            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                );
            app.UseIdentityServer();
            app.UseAuthorization();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}