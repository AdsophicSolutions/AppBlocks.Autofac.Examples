# Quick Start 

Quick Start projects gives you a quick introduction on using AppBlocks.Autofac. It demonstrates how to a create a single service using AppBlocks.Autofac. Build and run the service from command line to see results. You see will see aspect oriented logging in action. 

## Source Files

### Program.cs
The Main method in program.cs configures log4Net. 

### Example.cs
The Run method creates an ApplicationContainerBuilder and initializes an Autofac lifetime scope and runs the service. 

### ApplicationContainerBuilder.cs
Every AppBlocks.Autofac application must define a class that inherits from AppBlocksContainerBuilder. 
