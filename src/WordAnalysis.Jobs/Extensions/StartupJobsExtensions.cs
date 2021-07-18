using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Commands;
using WordAnalysis.Domain.Commands.Handlers;
using WordAnalysis.Domain.Model.Aggregates;
using WordAnalysis.Jobs.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupJobsExtensions
    {
        public static IServiceCollection AddWordAnalysisJobs(this IServiceCollection services)
        {
            services
                .AddWordAnalysisJobsAdapters()
                .AddWordAnalysisJobsServices()
                .AddWordAnalysisJobsApplicationServices()
                .AddWordAnalysisJobsRepositories();

            return services;
        }

        private static IServiceCollection AddWordAnalysisJobsAdapters(this IServiceCollection services)
        {
            //MapperConfiguration mappingConfig = new(mc =>
            //{
            //    mc.AddProfile(new WordCountAnalyticsMappingProfile());
            //});
            //services.AddSingleton<IMapper>(mappingConfig.CreateMapper());

            return services;
        }

        private static IServiceCollection AddWordAnalysisJobsServices(this IServiceCollection services)
        {
            services.AddScoped<IWordAnalyticsJobService, WordAnalyticsJobService>();

            return services;
        }

        private static IServiceCollection AddWordAnalysisJobsApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<ExternalWordCountCalculateCommand, ExternalWordCount>, ExternalWordCountCalculateCommandHandler>();
            return services;
        }


        private static IServiceCollection AddWordAnalysisJobsRepositories(this IServiceCollection services)
        {
            //string queueStorageConnectionString = configuration.GetConnectionString("QueueStorageConnectionString");
            //string queueStorageQueueName = configuration.GetConnectionString("QueueStorageQueueName");

            //services.Configure<QueueStorageOptions>(options =>
            //{
            //    options.ConnectionString = queueStorageConnectionString;
            //    options.QueueName = queueStorageQueueName;
            //});

            //services.AddScoped(typeof(ICommandDispatcher<ExternalWordCountCalculateCommand, ExternalWordCount>), typeof(CommandDispatcherRepository<ExternalWordCountCalculateCommand, ExternalWordCount>));

            //services.AddScoped(typeof(IQueueStorageRepository<>), typeof(QueueStorageRepository<>));

            return services;
        }
    }
}
