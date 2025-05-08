﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NTS.ApplicationServices.Packagess;
using NTS.WebServices.Authentifications.Services;
using System;
using System.Text;

namespace NTS.WebServices
{
    public class Startup
    {
        // The secret key every token will be signed with.
        // In production, you should store this securely in environment variables
        // or a key management tool. Don't hardcode this into your application!
        private static readonly byte[] secretKey = Encoding.ASCII.GetBytes("3c81df2689e91262dc636ae552e40bb09b0f25c32f1b50cd66f05628d5453d6d");

        private MapperConfiguration MapperConfiguration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationServicesAMConfiguration());
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInternalServices();
            services.AddSingleton<IMapper>(sp => MapperConfiguration.CreateMapper());

            var signingKey = new SymmetricSecurityKey(secretKey);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,

                        // Validate the JWT Issuer (iss) claim
                        ValidateIssuer = true,
                        ValidIssuer = "ExampleIssuer",

                        // Validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = "ExampleAudience",

                        // Validate the token expiry    
                        ValidateLifetime = true,

                        // If you want to allow a certain amount of clock drift, set that here:
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ArgumentNullException.ThrowIfNull(loggerFactory);

            app.UseStaticFiles();

            ////ILogger - log to local file
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            //loggerFactory.AddFile("C:/Logs/NTS-{Date}.txt");

            // Add JWT generation endpoint:
            var signingKey = new SymmetricSecurityKey(secretKey);
            var options = new TokenProviderOptions
            {
                Audience = "ExampleAudience",
                Issuer = "ExampleIssuer",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };

            app.UseMiddleware<ApplicationServices.ExceptionHandler.ExceptionMiddleware>();

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));

            app.UseRouting();
            app.UseAuthentication();  
            app.UseAuthorization(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
