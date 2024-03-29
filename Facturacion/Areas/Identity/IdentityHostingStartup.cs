﻿using System;
using Facturacion.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Facturacion.Areas.Identity.IdentityHostingStartup))]
namespace Facturacion.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FacturacionIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FacturacionContext")));

                services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<FacturacionIdentityContext>();
            });
        }
    }
}