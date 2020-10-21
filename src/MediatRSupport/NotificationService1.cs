using AppBlocks.Autofac.Support;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AppBlocks.Autofac.Examples.MediatRSupport
{
    [AppBlocksMediatrNotificationService]
    public class NotificationService1 : INotificationHandler<Notification>
    {
        private readonly ILogger<NotificationService1> logger;

        public NotificationService1(ILogger<NotificationService1> logger)
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
                        logger.LogInformation($"{nameof(NotificationService1)}.{nameof(Handle)} Received message {notification.Message}");
                }
            });
        }
    }
}
