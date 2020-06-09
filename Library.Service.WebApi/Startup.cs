using Library.Application;
using Library.Application.Commands.Mapper;
using Library.Application.Interfaces.ApiApp;
using Library.Application.Interfaces.Command;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using Library.Domain.Interfaces.UoW;
using Library.Domain.Services;
using Library.Infra.DataAccess;
using Library.Infra.DataAccess.Contexts;
using Library.Infra.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Library.Service.WebApi
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
            var infnetConnection = Configuration.GetConnectionString("InfnetConnection");
            services.AddControllers();
            services.AddDbContext<DbContext, LibraryContext>(o => o.UseMySQL(infnetConnection, b => b.MigrationsAssembly("Library.Infra.DataAccess")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookMySQLRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookApiApp, BookApiApp>();
            services.AddScoped<IBookCommandMapper, BookCommandMapper>();
            services.AddScoped<IPublisherRepository, PublisherMySQLRepository>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IPublisherApiApp, PublisherApiApp>();
            services.AddScoped<IPublisherCommandMapper, PublisherCommandMapper>();
            services.AddScoped<IVolumeRepository, VolumeMySQLRepository>();
            services.AddScoped<IVolumeService, VolumeService>();
            services.AddScoped<IVolumeApiApp, VolumeApiApp>();
            services.AddScoped<IVolumeCommandMapper, VolumeCommandMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
