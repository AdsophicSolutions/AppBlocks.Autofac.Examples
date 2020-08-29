# Application Context 

Application Context is a application wide dictionary that can be used to share application level information. Application context can be initialized via the appsettings.json file and can be modified during the life of the application

## Source Files

### Program.cs
The Main method in program.cs configures log4Net. 

### Example.cs
The Run method creates an ApplicationContainerBuilder and initializes an Autofac lifetime scope and runs the service. 

### ApplicationContainerBuilder.cs
Every AppBlocks.Autofac application must define a class that inherits from AppBlocksContainerBuilder. This inherited class is used to configure application Autofac services and other entities. In this example, ApplicationContainerBuilder creates a new ApplicationConfiguration instance using the appsettings.json file. The AppBlocks framework initializes the application context using this file. We also add a new application context key in the overriden RegisterExternalServices method. 

### IService.cs
Defines the sample service interface with a single method Run

### Service.cs
Implements the IService interface. The Service requests injection of IContext. In the Run method we access the previously created application context keys. 
