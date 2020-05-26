using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using vue_webApi.Entities;
using vue_webApi.MiddleWare;

namespace vue_webApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AskquestionsContext>();

            #region 引用swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "likes",
                    Version = "v1"

                });
                var xmlpath = AppDomain.CurrentDomain.BaseDirectory + "vue_webApi.xml";
                c.IncludeXmlComments(xmlpath);
            });
            #endregion

            #region 设置跨域
                            //跨域设置规则，            设置可以头部跨域      设置方法跨域       设置请求跨域
            services.AddCors(ac => ac.AddPolicy("any", ap => ap.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
            #endregion


            services.AddControllers();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<AuthMiddleware>();
            app.UseRouting();

            app.UseAuthorization();


            #region 配置swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "likes");
            });
            #endregion

            #region 加入跨域中间件
            app.UseCors();
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
