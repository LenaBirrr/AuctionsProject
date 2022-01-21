using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business.Services;
using Business.Repositories.DataRepositories;
using Repository.Repositories.DataRepositories;

namespace AuctionMVC
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;

        private readonly IConfigurationRoot _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
            var builder = new ConfigurationBuilder()
                .SetBasePath(_environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(_configuration);

            services.AddDbContext<Context>(
                options => options
                    .UseSqlServer(_configuration.GetConnectionString("DefaultConnection")),
                contextLifetime: ServiceLifetime.Singleton,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IAuctionHouseRepository, AuctionHouseRepository>();
            services.AddScoped<IAuctionItemRepository, AuctionItemRepository>();
            services.AddScoped<IAuctionRepository, AuctionRepository>();
            services.AddScoped<IEpochRepository, EpochRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ILotRepository, LotRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ISubtypeRepository,SubtypeRepository>();
            services.AddScoped<ITypeRepository,TypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServiceMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllersWithViews();
            services.AddScoped<IAuctionHouseService, AuctionHouseService>();
            services.AddScoped<IAuctionItemService, AuctionItemService>();
            services.AddScoped<IAuctionService, AuctionService>();
            services.AddScoped<IEpochService, EpochService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ILotService, LotService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ISubtypeService, SubtypeService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<IUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
