using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Vestibular.API.Configs;
using Vestibular.Aplication.Enums;
using Vestibular.Aplication.Services.CandidadoService;
using Vestibular.Aplication.Services.InscricaoService;
using Vestibular.Aplication.Services.OfertaService;
using Vestibular.Aplication.Services.ProcessoSeletivoService;
using Vestibular.Infraestrutura.Context;

namespace Vestibular.API
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
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.Converters.Add(new StringEnumConverter())); ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Vestibular.API",
                    Version = "v1",
                    Description = "Servidor que provê uma API com o objetivo de fornecer informações sobre Inscrições de candidatos de um vestibular",
                    Contact = new OpenApiContact { Name = "LinkedIn", Url = new Uri("https://linkedin.com/in/natan-lemes") }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                c.SchemaFilter<EnumSchemaFilter>();

            });
            services.AddDbContext<VestibularDbContext>();
            services.AddScoped<ICandidato, CandidatoService>();
            services.AddScoped<IProcessoSeletivo, ProcessoSeletivoService>();
            services.AddScoped<IOferta, OfertaService>();
            services.AddScoped<IInscricao, InscricaoService>();


            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vestibular.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
