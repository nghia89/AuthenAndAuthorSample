using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebNotIdentityFramework.Data;
using WebNotIdentityFramework.Helper;

[assembly: HostingStartup(typeof(WebNotIdentityFramework.Areas.Identity.IdentityHostingStartup))]
namespace WebNotIdentityFramework.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<BookStoreDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BookStoreDBContextConnection")));

                services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddDefaultUI()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<BookStoreDBContext>();
                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppliUserClaimsPrincipalFactory>();
                services.AddTransient<IEmailSender, EmailSender>();
            });
        }
    }
}