# Orchard Core Framework Samples

Sample web applications demonstrating how to build a Modular and Multi-Tenant ASP.NET Core application using the Orchard Core Framework.

You can watch a video providing a step by step demonstration of building a modular, multi-tenant Orchard Core Framework application here https://www.youtube.com/watch?v=yrQaKv2mxFU&list=PLReL099Y5nRd04p81Q7p5TtyjCrj9tz1t. It was presented at .NET Conf 2019 using Orchard Core RC1. The names of the C# projects in the demo do not match these sample projects, but the demonstration is very similar to these samples.

## 1. Solution - OrchardCore.Samples.sln
Contents of the `OrchardCore.Samples.sln` Solution has two modules and two web application as following.
### Projects 
#### a) MultiTenantApplication

An ASP.NET Core MVC application that references the modules projects, and provides two tenants with different modules enabled.

The homepage of this web application provides more information, and links to the two tenants and module endpoints. The tenants and their features are configured in the "OrchardCore" section of the appsettings.json file.

#### b) ModularApplication

A simple ASP.NET Core application that references the modules.

#### c) Module1

A sample module containing ASP.NET Core MVC controllers, views, and pages.

#### d) Module2

A sample module that registers custom middleware.

### Running OrchardCore.Samples.sln

### From Visual Studio 2019

Open the `OrchardCore.Samples.sln` solution file and run either application and visit its homepage (any project with a name ending in "Application"). 

Open the website in your browser, and use the URLs or links it provides to explore.

### From the Command Line

#### To Run Modular Application 

```dotnetcli
cd ModularApplication
dotnet restore
dotnet build
dotnet run
```

And, 
- Open Url `https://localhost:5001` in browser to launch the modular application.
- Open Url https://localhost:5001/WeatherForecast in browser to get the weather from Module1. 
- Open Url https://localhost:5001/Module2/hello to to run endpoint from Module2.


#### To Run MultiTenant Application


```dotnetcli
cd MultiTenantApplication
dotnet restore
dotnet build
dotnet run
```

And, 
 
- Open Url `https://localhost:5001` in browser to launch *Default* tenant or Open Url `https://localhost:5001/customer-a` or `https://localhost:5001/customer-b` specific tenant.  


The non-default tenants are prefixed with `/customer-a` and `/customer-b`.

For instance, accessing `/customer-b/Module2/hello` will invoke the middleware defined in **Module2**.

The tenants can be modified by editing the "OrchardCore" section of the `appsettings.json` file and restarting the application.

>Note that `tenants.json` is no longer supported in Orchard Core Framework applications, and tenant information is read from the "OrchardCore" section provided by any of the configuration providers.
In the MultiTenantApplication sample, the `appsettings.json` is used to configure the "OrchardCore" section. 

## 2. Solution - MultiTenantBlazorWasm.sln 
This sample demonstrates and creates modular single page application using Blazor WebAssembly with Orchard Core Framework. 

Contents of the `MultiTenantBlazorWasm.sln` Solution has one shared class library project, one blazor webassembly project and one  web application as following.

### Projects 
#### a) MultiTenantBlazorWasm.Client

A Blazor WebAssembly application that contains Blazor WebAssembly single page application.

#### b) MultiTenantBlazorWasm.Shared

A Class library that contains shared domain classes that used by both Blazor WebAssembly and Web Application projects.

#### c) MultiTenantBlazorWasm.Server

An ASP.NET Core MVC application that references both `MultiTenantBlazorWasm.Client` and `MultiTenantBlazorWasm.Shared` projects and provides two tenants with static files resolved from host `wwwroot`.

The tenants and their features are configured in the `OrchardCore` section of the `appsettings.json` file

### Running MultiTenantBlazorWasm.sln 

### From Visual Studio 2019

Open the `MultiTenantBlazorWasm/MultiTenantBlazorWasm.sln` solution file and run  visit its homepage. 

Open the website in your browser, and use the URLs or links it provides to explore.

### From the Command Line

#### To Run MultiTenantBlazorWasm

```dotnetcli
cd MultiTenantBlazorWasm/Server
dotnet restore
dotnet build
dotnet run
```

And, 
 
- Open Url `https://localhost:5001` in browser to launch *Default* tenant or Open Url `https://localhost:5001/customer-a` or `https://localhost:5001/customer-b` for specific tenant.  


The non-default tenants are prefixed with `/customer-a` and `/customer-b`.


# Creating new Modules

Modules can be .NET Standard 2.0 class libraries or .NET Core 3.0 class libraries that reference the **OrchardCore.Module.Targets** Nuget Package.

>Development (Nightly preview) Orchard Core Nuget packages are available at this url: `https://nuget.cloudsmith.io/orchardcore/preview/v3/index.json`

Optionally, modules can be packaged as Nuget packages and made available on Nuget including static files and views.
The Orchard Core CMS builds upon the Orchard Core Framework.

More examples of modules can be found for the Orchard Core CMS in this repository: https://github.com/OrchardCMS/OrchardCore

# Creating New Modular or Multi-Tenant Applications

A modular application that hosts module only needs to reference one of these targets packages:

- **OrchardCore.Application.Targets**: Allows the application to reference and import modules, and optionally use multi-tenancy.
- **OrchardCore.Application.Mvc.Targets**: Same as **OrchardCore.Application.Targets** but also references the **OrchardCore.Mvc** module
- **OrchardCore.Application.Nancy.Targets**: Same as **OrchardCore.Application.Targets** but also references the **OrchardCore.Nancy** module
