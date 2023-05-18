using DesSistemas.SnackNow.MessengerApi.Integration.Interfaces;
using DesSistemas.SnackNow.MessengerApi.Runner.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesSistemas.SnackNow.MessengerApi.Runner
{
    public class MessengerChatRunner : IHostedService
    {
        private readonly IMessengerIntegration _messengerIntegration;
        private readonly IServiceProvider _serviceProvider;
        private const int IntervalInMs = 30_000;

        public MessengerChatRunner(IMessengerIntegration messengerIntegration,
            IServiceProvider serviceProvider)
        {
            _messengerIntegration = messengerIntegration;
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("MessengerChatRunner - Starting execution.");
            var referenceDate = DateTime.Now;
            var count = 1;
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"MessengerChatRunner - Iteração {count}");
                await RunAsync(referenceDate);
                await Task.Delay(IntervalInMs, cancellationToken);
                referenceDate.AddMilliseconds(IntervalInMs);
                count++;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("MessengerChatRunner - Finishing execution.");
            return Task.CompletedTask;
        }

        private async Task RunAsync(DateTime referenceDate)
        {
            using var serviceScope = _serviceProvider.CreateScope();
            var messengerHandler = serviceScope.ServiceProvider.GetService<IMessengerHandler>()!;

            var messagesResponse = await _messengerIntegration.GetChatsAsync();
            if (messagesResponse.Data is null || !messagesResponse.Data.Any())
                return;

            var canBeContinue = await messengerHandler.HandleAsync(messagesResponse, referenceDate);
            while (canBeContinue)
            {
                messagesResponse = await _messengerIntegration.GetChatsAsync(messagesResponse.Paging.Cursors.After);
                if (messagesResponse.Data is null || !messagesResponse.Data.Any())
                    break;

                canBeContinue = await messengerHandler.HandleAsync(messagesResponse, referenceDate);
            }
        }
    }
}