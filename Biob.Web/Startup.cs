﻿using Biob.Data.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Biob.Data.Models;
using Biob.Services.Data.DtoModels;
using Biob.Web.Helpers;
using Biob.Services.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Biob.Services.Web.PropertyMapping;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Logging;

namespace Biob.Web
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
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());

                setupAction.InputFormatters.Add(new XmlSerializerInputFormatter(setupAction));


            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Configuration.GetConnectionString("BiobDB");
            services.AddDbContext<BiobDataContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IHallRepository, HallRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IHallSeatRepository, HallSeatRepository>();
            services.AddScoped<IShowtimeRepository, ShowtimeRepository>();



            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlHelper, UrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });

            services.AddTransient<IPropertyMappingService, PropertyMappingService>();
            services.AddTransient<ITypeHelperService, TypeHelperService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile("Logs/BioB-{Date}.txt");

            Mapper.Initialize(config => 
            {
                config.CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.LengthInSeconds.CalculateFromSeconds()));
                config.CreateMap<MovieToCreateDto, Movie>();
                config.CreateMap<MovieToUpdateDto, Movie>();
                config.CreateMap<Movie, MovieToUpdateDto>();
              
                config.CreateMap<Hall, HallDto>();
                config.CreateMap<HallToCreateDto, Hall>();
                config.CreateMap<HallToUpdateDto, Hall>();
                config.CreateMap<Hall, HallToUpdateDto>();

                config.CreateMap<Seat, SeatDto>();
                config.CreateMap<SeatToCreateDto, Seat>();
                config.CreateMap<SeatToUpdateDto, Seat>();
                config.CreateMap<Seat, SeatToUpdateDto>();

                config.CreateMap<HallSeat, HallSeatDto>();
                config.CreateMap<HallSeatToCreateDto, HallSeat>();
                config.CreateMap<HallSeatToUpdateDto, HallSeat>();
                config.CreateMap<HallSeat, HallSeatToUpdateDto>();

                config.CreateMap<Showtime, ShowtimeDto>();
                config.CreateMap<ShowtimeToCreateDto, Showtime>();
                config.CreateMap<ShowtimeToUpdateDto, Showtime>();
                config.CreateMap<Showtime, ShowtimeToUpdateDto>();
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
