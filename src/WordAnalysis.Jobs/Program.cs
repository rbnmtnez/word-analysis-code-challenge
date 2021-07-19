using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker.Configuration;

namespace WordAnalysis.Jobs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
#if DEBUG
            Debugger.Launch();
#endif
            var host = new HostBuilder()
                .ConfigureAppConfiguration(c =>
                {
                    c.AddCommandLine(args);
                })
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {
                    s.AddLogging();
                    s.AddWordAnalysisJobs();
                    //s.AddSingleton<IHttpResponderService, DefaultHttpResponderService>();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
