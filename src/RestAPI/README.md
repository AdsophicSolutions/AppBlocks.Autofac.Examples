# Rest API 

RestAPI demonstrates how to integrate AppBlocks into a REST API project. This project is created as a .NET Web REST API project. The project creates
`WeatherForecastController` by default. Here, we update the controller to be injected by an implementation of the service interface `IWeatherService`. `WeatherService` implements `IWeatherService` and provides `WeatherForecast` data

## Note
* Add Nuget reference to `Autofac.Extensions.DependencyInjection`
* Set the project as the start up project and run using F5.

## Source Files

### Program.cs
The Main method in program.cs configures log4Net. The method `CreateHostBuilder` is updated to include the line 
```
.UseServiceProviderFactory(new AutofacServiceProviderFactory())
```
to inject Autofac in the service pipeline

### Startup.cs
Add a new method 
```
public void ConfigureContainer(ContainerBuilder builder)
{
    var containerBuilder = new ApplicationContainerBuilder();
    containerBuilder.BuildContainer(builder);
}
```
We also save a reference to `ILifetimeScope`. This is included for completeness but not used. 

### ApplicationContainerBuilder.cs
Every AppBlocks.Autofac application must define a class that inherits from AppBlocksContainerBuilder. This inherited class is used to configure application Autofac services and other entities. In this example, ApplicationContainerBuilder performs the task of registering Autofac services in the application assembly. 

### IWeatherService.cs
Defines the weather service interface with a single method `GetWeatherForecasts`

### WeatherService.cs
Implementation for `IWeatherService` attributed with `AppBlocksService` attribute. This attribute informs the AppBlocks.Autofac framework to register the class as a Autofac container service. The AppBlocksService attribute without any parameters will default to registering the service as an implementation of the IService interface. Meaning that an instance of this class is provided when [Dependency](https://en.wikipedia.org/wiki/Dependency_injection) for the `IWeatherService` is defined. 

### WeatherForecaseController.cs
This class is generated when the project is created. We modify the default implementation by updating the constructor to include `IWeatherService` parameter. When the controller is created it is injected with an implementation of this interface. The `Get` method is modified to call the `GetWeatherForecasts` on the interface implementation.

### log4net.config
Logging configuration has been modified for this project to use a `FileAppender` instead of the `ConsoleAppender`. 
