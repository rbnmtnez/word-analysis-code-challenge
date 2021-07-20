using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Application.Services;
using WordAnalysis.Domain.Commands;
using WordAnalysis.Domain.Commands.Handlers;
using WordAnalysis.Domain.Model.Aggregates;
using WordAnalysis.Domain.Services.Interfaces;
using WordAnalysis.Infrastructure.Repositories;
using WordAnalysis.Jobs.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupJobsExtensions
    {
        public static IServiceCollection AddWordAnalysisJobs(this IServiceCollection services)
        {
            services
                .AddWordAnalysisJobsServices()
                .AddWordAnalysisJobsApplicationServices()
                .AddWordAnalysisJobsRepositories();

            return services;
        }

        private static IServiceCollection AddWordAnalysisJobsServices(this IServiceCollection services)
        {
            services.AddScoped<IWordAnalysisJobService, WordAnalysisJobService>();

            return services;
        }

        private static IServiceCollection AddWordAnalysisJobsApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<ExternalWordCountCalculateCommand, ExternalWordCount>, ExternalWordCountCalculateCommandHandler>();
            services.AddScoped<IWordAnalysisFactory, WordAnalysisFactory>();
            return services;
        }


        private static IServiceCollection AddWordAnalysisJobsRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWordAnalysisFileDownloaderService, WordAnalysisFileDownloaderRepository>();
            services.AddScoped<IWordAnalysisReplyService, WordAnalysisReplyServiceRepository>();

            services.AddHttpClient<IWordAnalysisFileDownloaderService, WordAnalysisFileDownloaderRepository>()
                    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                    .AddPolicyHandler(GetHttpRetryPolicy());

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetHttpRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
