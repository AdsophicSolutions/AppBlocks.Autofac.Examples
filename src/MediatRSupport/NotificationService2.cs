using AppBlocks.Autofac.Support;
using Autofac.Features.Indexed;
using log4net;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppBlocks.Autofac.Examples.MediatRSupport
{
    [AppBlocksMediatrNotificationService]
    public class NotificationService2 : INotificationHandler<Notification>
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Task Handle(Notification notification,
            CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                if (notification.Message == "0")
                {
                    if (logger.IsInfoEnabled)
                        logger.Info($"{nameof(NotificationService2)}.{nameof(Handle)} Received message {notification.Message}");
                }
            });
        }
    }
}
