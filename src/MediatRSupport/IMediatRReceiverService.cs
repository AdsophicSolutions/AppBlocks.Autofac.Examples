using System;
using System.Collections.Generic;
using System.Text;

namespace AppBlocks.Autofac.Examples.MediatRSupport
{
    public interface IMediatRReceiverService
    {
        void RunRequest();
        void RunNotification();
    }
}
