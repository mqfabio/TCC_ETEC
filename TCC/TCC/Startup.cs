using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TCC.Data;
using TCC.Models;

namespace TCC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddSingleton<IExcluido, Excluido>();
            //services.AddSingleton<IExcluidoRepositorio, ExcluidoRepositorio>();
            services.AddSingleton<IEvento, Evento>();
            services.AddSingleton<IEventoRepositorio, EventoRepositorio>();
            services.AddSingleton<IUsuario, Usuario>();
            services.AddSingleton<IUsuarioRepositorio, UsuarioRepositorio>();
            

            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API TCC",
                    Description = "API que fizemos para o TCC",
                    Contact = new OpenApiContact
                    {
                        Name = "F�bio Martinez",
                        Email = "fabio@gmail.com"
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meu TCC");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
