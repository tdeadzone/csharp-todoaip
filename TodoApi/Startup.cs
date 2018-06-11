using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;
using TodoApi.Models;

namespace TodoApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // services.AddCors();
        }

        public void Configure(IApplicationBuilder app)
        {
            // 下面这种方式太放水
            // app.UseCors(
            //  builder => builder
            //     .AllowAnyOrigin()
            //     .AllowAnyMethod()
            //     .AllowAnyHeader()
            //     .AllowCredentials()
            // );
            // 为特权域放行
            // app.UseCors(
            //     options => options
            //         .WithOrigins("http://localhost").AllowAnyMethod()
            // );
            app.UseMvc();
        }
    }
}