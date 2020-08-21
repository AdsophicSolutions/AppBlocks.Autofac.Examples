# Service Dependency Injection
Demonstrates how to one service implementation can be injected into another service implementation via the constructor. Service1 implements the IService1 interface but requires an implementation of IService2 interface to be injected into its constructor. This dependency is satisfied by an instance Service2, since Service2 implements the IService2 interface and is attributed with the AppBlocksService attribute

## Source Files

### Program.cs
The Main method in program.cs configures log4Net. 

### Example.cs
The Run method creates an ApplicationContainerBuilder and initializes an Autofac lifetime scope, resolves and runs IService. 

### ApplicationContainerBuilder.cs
Every AppBlocks.Autofac application must define a class that inherits from AppBlocksContainerBuilder. This inherited class is used to configure application Autofac services and other entities. In this example, ApplicationContainerBuilder performs the task of registering Autofac services in the application assembly. 

### IService1.cs and IService2.cs
Defines two sample service interfaces. IService1 defines a single method RunService1 and IService2 defines a single method RunService2

### Service1.cs
Implementation for IService1 attributed with AppBlocksService attribute. This attribute informs the AppBlocks.Autofac framework to register the class as a Autofac container service. The AppBlocksService attribute without any parameters will default to registering the service as an implementation of the IService1 interface. Meaning that an instance of this class is provided when [Dependency](https://en.wikipedia.org/wiki/Dependency_injection) for the IService1 is defined. Via its constructor, it defines a dependency on an IService2 implementation.  

### Service2.cs 
Implementation for IService2 attributed with AppBlocksService attribute. Similarly to Service1, this attribute informs the AppBlocks.Autofac framework to register the class as a Autofac container service. The AppBlocksService attribute without any parameters will default to registering the service as an implementation of the IService2 interface. Meaning that an instance of this class is provided when [Dependency](https://en.wikipedia.org/wiki/Dependency_injection) for the IService2 is defined. In this example, an instance of this class is used to satisfy the IService2 dependency defined by the Service1 class constructor.




