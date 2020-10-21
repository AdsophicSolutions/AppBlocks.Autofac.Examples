using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.ValidatorAndWorkflowWriter
{
    [AppBlocksWorkflowWriterService("Application")]
    public class ApplicationWorkflowWriter : IWorkflowWriter
    {
        private readonly ILogger<ApplicationWorkflowWriter> logger;
        public ApplicationWorkflowWriter(ILogger<ApplicationWorkflowWriter> logger)
        {
            this.logger = logger;
        }
        public void PreMethodInvocationOutput(IInvocation invocation)
        {
            // Nothing to do before call service method is made
        }

        public void PostMethodInvocationOutput(IInvocation invocation)
        {
            // Workflow writer writes out information that call was completed
            // successfully
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"Call to {invocation.TargetType.FullName}.{invocation.Method} completed successfully. " +
                    $"The return value is {invocation.ReturnValue}");
        }
    }
}
