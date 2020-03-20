using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Services.Utility;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {




            //-----------------EntityFramework----------------//

            services.AddDbContext<MyDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //----------------------------------------------------//


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //what to validate
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            //Setup validation data
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
        };
    });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200",
                                        "http://www.contoso.com")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });


            services.AddMvc(config =>
            {

                config.RespectBrowserAcceptHeader = true;
                config.InputFormatters.Add(new XmlSerializerInputFormatter());
                config.OutputFormatters.Add(new XmlSerializerOutputFormatter());

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            // .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseExceptionHandler("/Error");
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //app.Run(async (context) =>

            //{
            //    await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            //});

            // app.UseStatusCodePagesWithRedirects("/Errorcode/{0}");


            //  app.UseCustomAuthorize();

            app.UseAuthentication();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc();



        }

    }
}
