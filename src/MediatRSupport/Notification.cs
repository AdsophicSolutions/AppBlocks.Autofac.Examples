using MediatR;

namespace AppBlocks.Autofac.Examples.MediatRSupport
{
    public class Notification : INotification
    {
        public string Message { get; set; }

        public override string ToString() => $"Message: {Message}";
    }
}
