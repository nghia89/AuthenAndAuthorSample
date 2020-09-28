using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebNotIdentityFramework.Data;

[assembly: HostingStartup(typeof(WebNotIdentityFramework.Areas.Identity.IdentityHostingStartup))]
namespace WebNotIdentityFramework.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BookStoreDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BookStoreDBContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BookStoreDBContext>();
            });
        }
    }
}