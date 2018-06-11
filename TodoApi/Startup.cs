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
            services.AddCors(
                options =>
                options.AddPolicy("AllowCors",
                builder =>
                {
                    builder
                        .AllowAnyOrigin() // 放行所有的域
                                          //.WithOrigins('http://localhost', 'http://www.himgloves.com')
                        .AllowAnyMethod() // 放行所有的方法
                                          //.WithMethods('GET', 'PUT', 'POST', 'DELETE')
                        .AllowAnyHeader(); // 放行所有的http头部
                                           //.WithHeaders("Accept", "Content-type", "Origin", "X-Custion-Header")
                })
            );
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
            // app.UseCors("AllowCors"); // 必须放在UseMvc中间件的上面
            app.UseMvc();
        }
    }
}