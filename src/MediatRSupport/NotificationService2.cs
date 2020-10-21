using AppBlocks.Autofac.Support;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AppBlocks.Autofac.Examples.MediatRSupport
{
    [AppBlocksMediatrNotificationService]
    public class NotificationService2 : INotificationHandler<Notification>
    {
        private readonly ILogger<NotificationService2> logger;

        public NotificationService2(ILogger<NotificationService2> logger)
        {
            this.logger = logger;
        }

        public Task Handle(Notification notification,
            CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                if (notification.Message == "0")
                {
                    if (logger.IsEnabled(LogLevel.Information))
                        logger.LogInformation($"{nameof(NotificationService2)}.{nameof(Handle)} Received message {notification.Message}");
                }
            });
        }
    }
}
