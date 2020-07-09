using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Castle.DynamicProxy;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.ValidatorAndWorkflowWriter
{
    [AppBlocksValidatorService("AppBlocks.Autofac.Examples.ValidatorAndWorkflowWriter.Service")]
    public class ServiceValidator : IServiceValidator
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void ValidateInputParameters(IInvocation invocation)
        {
            if(logger.IsInfoEnabled)
            {
                logger.Info($"Validating input parameters for {invocation.Method.Name}");
                if((string)invocation.Arguments[0] == "hello world")
                    logger.Info($"Parameter value hello world is valid");
            }
        }

        public void ValidateResult(IInvocation invocation)
        {
            if (logger.IsInfoEnabled)
            {
                logger.Info($"Validating return value for {invocation.Method.Name}");
                if ((int)invocation.ReturnValue == 0)
                    logger.Info($"Return value is 0 is valid");                
            }
        }
    }
}
