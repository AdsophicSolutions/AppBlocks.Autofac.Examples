using AppBlocks.Autofac.Support;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.MediatRSupport
{
    [AppBlocksService]
    public class MediatRReceiverService : IMediatRReceiverService
    {
        private readonly ILogger<MediatRReceiverService> logger;
        private IMediator Mediator { get; }

        public MediatRReceiverService(ILogger<MediatRReceiverService> logger, IMediator mediator)
        {
            this.logger = logger;
            Mediator = mediator;
        }

        public void RunRequest()
        {
            var request = new Request { Input = "0" };
            var response = Mediator
                    .Send(request)
                    .GetAwaiter()
                    .GetResult();

            if (response.Output == "1")
            {
                if (logger.IsEnabled(LogLevel.Information))
                    logger.LogInformation($"Received response in " +
                        $"{nameof(MediatRReceiverService)}.{nameof(RunRequest)}");
            }
        }

        public void RunNotification()
        {
            var notification = new Notification { Message = "0" };
            
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"Publishing notification in " +
                    $"{nameof(MediatRReceiverService)}.{nameof(RunNotification)}");

            Mediator.Publish(notification).GetAwaiter().GetResult();
        }
    }
}
