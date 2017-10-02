# Orchard Core Samples

A sample web application demonstrating how to build a Modular and Multi-Tenant ASP.NET Core application using the Orchard Core Framework. You can also watch a video providing a step by step demonstration of these samples here https://channel9.msdn.com/Shows/On-NET/Sbastien-Ros-Modular-ASPNET-apps

## Contents of the solution

#### ModularApplication

An ASP.NET Core MVC application that references the modules.

#### MultiTenantApplication

An ASP.NET Core MVC application that references the modules and starts two tenants with different modules enabled.

#### Module1

A sample module containing an ASP.NET Core MVC controller and a view.

The action can be accessed at `/Module1/Home/Index`.

#### Module2

A sample module registering a custom middleware.

- `/hello` emits `hello world`
- `/info` emits the name of the current tenant

## Running

### From Visual Studio 2017

Open the `ModularApplication.sln` solution file and start the Web applications.

To test **Module1** open the `/Module1/Home/Index` url.
To test **Module2** open the `/hello` url.

### From the command line

Open either Web application folder, `ModularApplication` or `MultiTenantApplication`, then run these commands:

- `dotnet restore`
- `dotnet build`
- `dotnet run`

### Multi-tenant

The tenants are prefixed with `/acme` and `/contoso`. For instance, accessing `/acme/hello` will invoke the middleware defined in **Module2**. You can check which tenant is invoked by accessing the `/acme/info` or `/contoso/info` urls.

The tenants can be modified by editing the `tenants.json` file and restarting the application.

## Creating new Modules

Modules are .NET Standard 1.6 class libraries that reference the **OrchardCore.AsModule** Nuget Package.

The Orchard Core Nuget packages are available in a MyGet feed at this url: `https://www.myget.org/F/orchardcore-preview/api/v3/index.json`

From the Web application, just reference a module project and it will be available.

Optionally modules can be packaged as Nuget packages and made available on Nuget or MyGet, including static files and Views.
More examples of modules can be found on the Orchard Core CMS application on this repository: https://github.com/OrchardCMS/Orchard2

