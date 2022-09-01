using System;
using InnSystem.Areas.Identity.Data;
using InnSystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(InnSystem.Areas.Identity.IdentityHostingStartup))]
namespace InnSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<InnSystemContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("InnSystemContextConnection")));

                services.AddDefaultIdentity<InnSystemUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<InnSystemContext>();
            });
        }
    }
}