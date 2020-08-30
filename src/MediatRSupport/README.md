# MediatR 

AppBlocks provides integrated support for MediatR. This example demonstrates how MediatR notification and request service can be in AppBlocks.


## Source Files

### Program.cs
The Main method in program.cs configures log4Net. 

### Example.cs
The Run method creates an ApplicationContainerBuilder and initializes an Autofac lifetime scope and runs the service. 

### ApplicationContainerBuilder.cs
Every AppBlocks.Autofac application must define a class that inherits from AppBlocksContainerBuilder. This inherited class is used to configure application Autofac services and other entities. In this example, ApplicationContainerBuilder performs the task of registering Autofac services in the application assembly. 

### IMediatRReceiverService.cs
Defines the sample service interface with a methods RunRequest and RunNotification

### MediatRReceiverService.cs
Implements IMediatRReceiverService and sets up dependency injection to receive IMediator implementation. This implementation can be used send requests and notifications via MediatR. In RunRequest method it creates an instance of Request and in RunNotification it creates an instance of the Notification and calls the MediatR implementation with the instance. It is attributed as a AppBlocks service. 

### Notification.cs and Request.cs and Response.cs
Notification, Request, Response message classes. 

### NotificationService1.cs and NotificationService2.cs
Implement INotificationHandler for Notification message. They are attributed with AppBlocksMediatrNotificationService. Notifications can be handled by multiple handlers. Notifications sent via MediatR implementation are handled here. 

### RequestResponseService.cs
Registered as request handlers for Request message providing a response of type Response. Class implements interface IRequestHandler and is attributed with AppBlocksMediatrRequestService. Handle method is called via the MediatR implementation



