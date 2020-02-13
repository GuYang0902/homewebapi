using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using home.dbhelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace home.api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => options.AddPolicy("CorsPolicy",
builder =>
{
    builder.AllowAnyMethod()
    .SetIsOriginAllowed(_ => true)
    .AllowAnyHeader()
    .AllowCredentials();
}));


            services.AddControllers();

            services.AddScoped<Chloe.IDbContext>((serviceProvider) =>
            {
                return new Chloe.MySql.MySqlContext(new MySqlConnectionFactory(DBConfig.HomeMysqlConn).CreateConnection);
            });






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");

            app.UseRouting();
   
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
