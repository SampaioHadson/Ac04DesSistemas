using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;

namespace DesSistemas.SnackNow.Api.Domain.Jobs
{
    public class CheckPendingPaymentsHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public CheckPendingPaymentsHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var service = scope.ServiceProvider.GetService<ICheckPaymentsJobService>();
                    await service!.RunAsync();
                    await Task.Delay(30_000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("ENDING");
        }
    }
}
