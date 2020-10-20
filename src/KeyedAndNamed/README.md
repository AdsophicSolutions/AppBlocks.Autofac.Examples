# Keyed and Named Services
Demonstrates how to use Keyed and Named services using AppBlocks.Autofac. 

In Keyed services, an implementation for an interface can be attributed with a key. During dependency injection an instance of the implementation is passed in with the key information. The receiver has the ability to choose the implementation to call.

Named Services supports attributing a service with a name. The service can then be resolved using that name. 

## Source Files

### Program.cs
The ConfigureLogging method in program.cs configures logging. The default implementation uses log4net. Pass command line parameter seri to use serilog instead.  

### Example.cs
The Run method creates an ApplicationContainerBuilder and initializes an Autofac lifetime scope. It demonstrates how to resolve a named service and calls a receiver for a keyed service.

### IKeyedService.cs and INamedService.cs
Defines service interfaces for keyed service and named service. 

### KeyedService1.cs and KeyedService2.cs
Provides the two implementations for IKeyedService interface. The classes use the attribute AppBlocksKeyedService to register implementatation as keyed services. KeyedService1 specifies the key "KeyedService1" while KeyedService2 specifies the key "KeyedService2".

### NamedService.cs
Provides implementation of INamedService. It uses the attribute AppBlocksNamedService to register the service with the name "AppBlocks.Autofac.Examples.KeyedAndNamed.NamedService".

### KeyedServiceReciever
Defines a constructor with a dependency on IIndex<string, IKeyedService>. This dependency is satisfied with an instance of all classes that implement IKeyedService interface and are attributed with AppBlocksKeyedService. In RunKeyedServices method, we use the dependency to look up specific instances of keyed service implementations and call the method RunKeyedService. 
