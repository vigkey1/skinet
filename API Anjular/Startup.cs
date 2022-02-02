using API_Anjular.Errors;
using API_Anjular.Extension;
using API_Anjular.Helper;
using API_Anjular.MiddleWare;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace API_Anjular
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

      
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();
            services.AddDbContext<StoreContext>(x => x.UseSqlite(_Configuration.GetConnectionString("DefaultConnection")));
            services.AddApplicationService();
            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwaggerDocumentation();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


