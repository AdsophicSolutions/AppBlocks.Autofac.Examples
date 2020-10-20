# Quick Start 

Quick Start projects gives you a quick introduction on using AppBlocks.Autofac. It demonstrates how to a create a single service using AppBlocks.Autofac. Build and run the service from command line to see results. You see will see aspect oriented logging in action. 

## Source Files

### Program.cs
The Main method in program.cs configures logging. The default implementation uses log4net. Pass command line parameter seri to use serilog instead.  

### Example.cs
The Run method creates an ApplicationContainerBuilder and initializes an Autofac lifetime scope and runs the service. 

### ApplicationContainerBuilder.cs
Every AppBlocks.Autofac application must define a class that inherits from AppBlocksContainerBuilder. This inherited class is used to configure application Autofac services and other entities. In this example, ApplicationContainerBuilder performs the task of registering Autofac services in the application assembly. 

### IService.cs
Defines the sample service interface with a single method Run

### Service.cs
Implementation for IService attributed with AppBlocksService attribute. This attribute informs the AppBlocks.Autofac framework to register the class as a Autofac container service. The AppBlocksService attribute without any parameters will default to registering the service as an implementation of the IService interface. Meaning that an instance of this class is provided when [Dependency](https://en.wikipedia.org/wiki/Dependency_injection) for the IService is defined.
