using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Castle.DynamicProxy;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace AppBlocks.Autofac.Examples.ValidatorAndWorkflowWriter
{
    [AppBlocksWorkflowWriterService("Application")]
    public class ApplicationWorkflowWriter : IWorkflowWriter
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void PreMethodInvocationOutput(IInvocation invocation)
        {
            // Nothing to do before call service method is made
        }

        public void PostMethodInvocationOutput(IInvocation invocation)
        {
            // Workflow writer writes out information that call was completed
            // successfully
            if (logger.IsInfoEnabled)
                logger.Info($"Call to {invocation.TargetType.FullName}.{invocation.Method} completed successfully. The return value is {invocation.ReturnValue}");
        }
    }
}
