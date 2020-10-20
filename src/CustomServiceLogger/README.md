# Custom Service Logger

Examples demonstrates how to declare a custom logger tasked with logging service requests and responses. 

## Source Files

### Program.cs
The Main method in program.cs configures logging. The default implementation uses log4net. Pass command line parameter seri to use serilog instead.

### Example.cs
The Run method creates an ApplicationContainerBuilder and initializes an Autofac lifetime scope and runs two service interfaces, IService and IAsyncService.

### IService.cs
Defines a simple service interface with a single method Run. 

### IAsyncService.cs
Defines a simple service with a single method Run which returns Task and can be implemented using Async / Await pattern.

### Service.cs and AsyncService.cs
Implementations for IService and IAsyncService interface. Attributed as AppBlocksService.

### ServiceLogger.cs and AsyncServiceLogger.cs
Both the classes implement the IServiceLogger interface. They are attributed using AppBlocksServiceLogger. Parameter to the attribute specifies the full name of the service type this logger logs for. ServiceLogger therefore becomes the custom logger for service AppBlocks.Autofac.Examples.CustomServiceLogger.Service and AsyncServiceLogger is configured as the custom logger for service AppBlocks.Autofac.Examples.CustomServiceLogger.AsyncService. The PreMethodInvocation IServiceLogger method is called before any service method is called.  PostMethodInvocationLog is called after the service method returns. NOTE: Utility.GetAsyncInvocationResult must be used to retrieve return value from any async method, invocation.ReturnValue will not work.

