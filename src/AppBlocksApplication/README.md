# AppBlocks Application : Using Modules  

Example demonstrates two features of AppBlocks. One, it supports dynamically loading assemblies based on a configuration. Two, register AppBlocks entities from other assemblies. 

## Source Files

## AppBlocksApplication Project
This is the startup project.

### Program.cs
The Main method in program.cs configures log4Net. 

### Example.cs
Creates an instance of ApplicationConfiguration initialized with appsettings.json.  Next, creates an ApplicationContainerBuilder and passes the instance of ApplicationConfiguration and initializes an Autofac lifetime scope and runs the service. 

### appSettings.json
Provides application configuration. autofacSourceDirectories list is the source of other Autofac assemblies to be loaded dynamically. 

### ApplicationContainerBuilder.cs
Every AppBlocks.Autofac application must define a class that inherits from AppBlocksContainerBuilder. This inherited class is used to configure application Autofac services and other entities. In this example, ApplicationContainerBuilder performs the task of registering Autofac services in the application assembly. It also creates registers assembly AppBlocksModule via AppBlocksModuleImpl from AppBlocksModule project. 

### IService.cs
Defines the sample service interface with a single method Run

### Service.cs
Implementation for IService attributed with AppBlocksService attribute. It introduces dependencies on IModuleService and SingleInstanceModuleService in its constructor. These implementations are defined in AppBlocksModule project. In the Run method it calls methods on the dependencies. 

## AppBlocksModule
Project is referenced as a project dependency in AppBlocksApplication project

### AppBlocksModuleImpl.cs
AppBlocksModuleImpl class is used to register AppBlocks service in the AppBlocksModule project. In this example, it explicitly registers SingleInstanceModuleService as a single instance service. This instance will be shared across the container.  It also calls RegisterAssembly in base implementation to register AppBlocks services defined in the project. 

### SingleInstanceModuleService.cs
Class that defines the method run. Note that this class is not attributed with the any AppBlocks service attribute. This is because AppBlocksModuleImpl explicitly adds an instance of this class as an AppBlocks single instance service. 

### IModuleService.cs
Defines a sample service with a single method RunModuleService. 

### ModuleService.cs
Implementation for IModuleService. It is attributed with AppBlocksService. 

## AppBlocksLoggingModule
Dynamically loaded assembly

### AssemblyInfo.cs
Defines the assembly attribute AppBlocksAssembly. This is necessary for AppBlocks to identify an assembly as an AppBlocks assembly. Only assemblies marked with this attribute are dynamically loaded.

### ModuleServiceLogger.cs
Defines a custom logger for type AppBlocks.Autofac.Examples.AppBlocksModule.ModuleService. This logger will intercept method calls to the ModuleService. 


