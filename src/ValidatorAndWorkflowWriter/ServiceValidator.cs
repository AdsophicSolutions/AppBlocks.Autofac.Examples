using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.ValidatorAndWorkflowWriter
{
    [AppBlocksValidatorService("AppBlocks.Autofac.Examples.ValidatorAndWorkflowWriter.Service")]
    public class ServiceValidator : IServiceValidator
    {
        private readonly ILogger<ServiceValidator> logger;
        public ServiceValidator(ILogger<ServiceValidator> logger)
        {
            this.logger = logger;
        }

        public void ValidateInputParameters(IInvocation invocation)
        {
            if(logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation($"Validating input parameters for {invocation.InvocationTarget.GetType().FullName}.{invocation.Method.Name}");
                if((string)invocation.Arguments[0] == "hello world")
                    logger.LogInformation($"Parameter value hello world is valid");
            }
        }

        public void ValidateResult(IInvocation invocation)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation($"Validating return value for {invocation.InvocationTarget.GetType().FullName}.{invocation.Method.Name}");
                if ((int)invocation.ReturnValue == 0)
                    logger.LogInformation($"Return value is 0 is valid");                
            }
        }
    }
}
