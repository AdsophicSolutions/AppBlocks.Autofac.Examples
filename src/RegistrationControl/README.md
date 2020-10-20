# Registration Control 

Registration control introduces the concept of selective registration of services. Registration control can especially be useful in test projects where mock services are used. There are two ways to control service registration. A service attributed as live service does not get called when the application is running in Test mode. Services can also be explicitly filtered out. 

## Source Files

### Program.cs
The ConfigureLogging method in program.cs configures logging. The default implementation uses log4net. Pass command line parameter seri to use serilog instead.  

### Example.cs
The Run method creates an ApplicationContainerBuilder and initializes an Autofac lifetime scope and runs the service. 

### ApplicationContainerBuilder.cs
Every AppBlocks.Autofac application must define a class that inherits from AppBlocksContainerBuilder. This inherited class is used to configure application Autofac services and other entities. In this example, ApplicationContainerBuilder specifies parameter AppBlocksApplicationMode.Test to the base constructor to indicate this application runs in test mode. It also filters out service with type name AppBlocks.Autofac.Examples.RegistrationControl.FilteredOutService. 

### IService.cs
Defines the sample service interface with a single method Run

### Service.cs
Implementation for IService interface. Registered using AppBlocksService attribute. 

### LiveService.cs
Implements IService interface. Throws an exception in Run method. The service is filtered out during registration since it is attributed with AppBlocksLiveService and the sample application is configured to run in Test mode. When application is run, no exception is thrown since this service is never registered. 

### FilteredOutService.cs 
Implements IService interface. Throws an exception in Run method. The service is filtered out by ShouldRegisterService method in ApplicationContainerBuilder. When application is run, no exception is thrown since this service is never registered. 
