# Validator and Workflow Writer 

Example introduces the concept of declaring validator and workflow writers. Validators setup on a service implementation are called before and after method on the service are called. Validators are similar to custom loggers but they are differentiated by intent. Validators should be used to validate data inputs and outputs, whereas loggers should be used to perform logging. Workflow writers are intended to tie together data flows. Workflow writers are identified by a workflow writer name. A service is then attributed with that workflow writer name - in which case workflow writer is called before and after any service method is called. 

## Source Files

### Program.cs
The ConfigureLogging method in program.cs configures logging. The default implementation uses log4net. Pass command line parameter seri to use serilog instead.  

### Example.cs
The Run method creates an ApplicationContainerBuilder and initializes an Autofac lifetime scope and runs the service. 

### ApplicationContainerBuilder.cs
Every AppBlocks.Autofac application must define a class that inherits from AppBlocksContainerBuilder. This inherited class is used to configure application Autofac services and other entities. In this example, ApplicationContainerBuilder performs the task of registering Autofac services in the application assembly. 

### IService.cs
Defines a service interface with a single method Run.

### Service.cs
Service class implements the IService interface. The Service class is attributed using AppBlocksService attribute which configures the service for Logging and Validation interceptor. A service can be intercepted of multiple workflow writers. Here, the service is intercepted by the "Application" workflow writer.

### ServiceValidator.cs
ServiceValidator implements the IServiceValidator interface. Using the attribute AppBlocksValidatorService registers it as the validator for type AppBlocks.Autofac.Examples.ValidatorAndWorkflowWriter.Service. Validator methods are called before and after Service methods are called. 

### ApplicationWorkflowWriter.cs
ApplicationWorkflowWriter implements the IWorkflowWriter interface. Using the attribute AppBlocksWorkflowWriterService is used to register the class as workflow writer with name "Application". Any service attributed to be intercepted by workflow writer "Application" will be intercepted by this class. 

