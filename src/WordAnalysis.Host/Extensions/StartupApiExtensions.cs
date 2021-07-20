using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordAnalysis.API.Adapters.MapperProfiles;
using WordAnalysis.API.Services;
using WordAnalysis.Domain.Commands;
using WordAnalysis.Domain.Model.Aggregates;
using WordAnalysis.Domain.Services.Interfaces;
using WordAnalysis.Host.Controllers;
using WordAnalysis.Infrastructure.Repositories;
using WordAnalysis.Infrastructure.Repositories.QueueStorage;

namespace WordAnalysis.Host.Extensions
{
    public static class StartupApiExtensions
    {
        public static IServiceCollection AddWordAnalysisServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddWordAnalysisAdapters()
                .AddWordAnalysisAPIServices()
                .AddWordAnalysisApplicationServices()
                .AddWordAnalysisRepositories(configuration);

            return services;
        }

        public static IMvcBuilder AddWordAnalysisAPIControllers(this IMvcBuilder mvcBuilder)
        {
            return mvcBuilder.AddApplicationPart(typeof(WordCountAnalyticsController).Assembly);
        }

        private static IServiceCollection AddWordAnalysisAdapters(this IServiceCollection services)
        {
            MapperConfiguration mappingConfig = new(mc =>
            {
                mc.AddProfile(new WordCountAnalysisMappingProfile());
            });
            services.AddSingleton<IMapper>(mappingConfig.CreateMapper());

            return services;
        }

        private static IServiceCollection AddWordAnalysisAPIServices(this IServiceCollection services)
        {
            services.AddScoped<IWordService, WordService>();

            return services;
        }

        private static IServiceCollection AddWordAnalysisApplicationServices(this IServiceCollection services)
        {
            return services;
        }


        private static IServiceCollection AddWordAnalysisRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            string queueStorageConnectionString = configuration.GetConnectionString("QueueStorageConnectionString");
            string queueStorageQueueName = configuration.GetConnectionString("QueueStorageQueueName");

            services.Configure<QueueStorageOptions>(options =>
            {
                options.ConnectionString = queueStorageConnectionString;
                options.QueueName = queueStorageQueueName;
            });

            services.AddScoped(typeof(ICommandDispatcherService<ExternalWordCountCalculateCommand, ExternalWordCount>), typeof(CommandDispatcherRepository<ExternalWordCountCalculateCommand, ExternalWordCount>));

            services.AddScoped(typeof(IQueueStorageRepository<>), typeof(QueueStorageRepository<>));

            return services;
        }

    }
}
