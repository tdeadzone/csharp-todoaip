using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using TodoApi.Models;

namespace TodoApi
{
    public class Startup
    {
        // 这个方法是【必须的】配置请求中间件
        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors("AllowSpecificOrigin");
            app.UseMvc();
        }
        // 这个方法是【可选的】配置应用所需的服务
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(
                opt =>
                    opt.UseInMemoryDatabase("TodoList")
            );

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );
            });
        }
    }
}