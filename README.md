# Orchard Core Framework Samples

Sample web applications demonstrating how to build a Modular and Multi-Tenant ASP.NET Core application using the Orchard Core Framework.

You can watch a video providing a step by step demonstration of building a modular, multi-tenant Orchard Core Framework application here https://www.youtube.com/watch?v=yrQaKv2mxFU&list=PLReL099Y5nRd04p81Q7p5TtyjCrj9tz1t. It was presented at .NET Conf 2019 using Orchard Core RC1. The names of the C# projects in the demo do not match these sample projects, but the demonstration is very similar to these samples.

## Contents of the Solution

### MultiTenantApplication

An ASP.NET Core MVC application that references the modules projects, and provides two tenants with different modules enabled.

The homepage of this web application provides more information, and links to the two tenants and module endpoints. The tenants and their features are configured in the "OrchardCore" section of the appsettings.json file.

### ModularApplication

A simple ASP.NET Core application that references the modules.

### DashboardApplication

An ASP.NET Core MVC application with Orchard Admin UI that references the modules projects.

The application has minimal features and dependencies. There are users, roles and features management in admin UI. The sample contains a customizable minimal setup recipe.

### Module1

A sample module containing ASP.NET Core MVC controllers, views, and pages.

### Module2

A sample module that registers custom middleware.

## Running

### From Visual Studio 2019

Open the `OrchardCore.Samples.sln` solution file and run either application and visit its homepage (any project with a name ending in "Application"). 

Open the website in your browser, and use the URLs or links it provides to explore.

### From the Command Line

Open either Web application folder, `ModularApplication` or `MultiTenantApplication`, then run these commands:

- `dotnet restore`
- `dotnet build`
- `dotnet run`

### Multi-Tenant

The non-default tenants are prefixed with `/customer-a` and `/customer-b`.
For instance, accessing `/customer-b/Module2/hello` will invoke the middleware defined in **Module2**.

The tenants can be modified by editing the "OrchardCore" section of the appsettings.json file and restarting the application.

Note that tenants.json is no longer supported in Orchard Core Framework applications, and tenant information is read from the "OrchardCore" section provided by any of the configuration providers.
In the MultiTenantApplication sample, the appsettings.json is used to configure the "OrchardCore" section.

## Creating new Modules

Modules can be .NET Standard 2.0 class libraries or .NET Core 3.0 class libraries that reference the **OrchardCore.Module.Targets** Nuget Package.

If you need it, development Orchard Core Nuget packages are available in a MyGet feed at this url: `https://nuget.cloudsmith.io/orchardcore/preview/v3/index.json`

Optionally, modules can be packaged as Nuget packages and made available on Nuget or MyGet, including static files and views.
The Orchard Core CMS builds upon the Orchard Core Framework.
More examples of modules can be found for the Orchard Core CMS in this repository: https://github.com/OrchardCMS/OrchardCore

## Creating New Modular or Multi-Tenant Applications

A modular application that hosts module only needs to reference one of these targets packages:

- **OrchardCore.Application.Targets**: Allows the application to reference and import modules, and optionally use multi-tenancy.
- **OrchardCore.Application.Mvc.Targets**: Same as **OrchardCore.Application.Targets** but also references the **OrchardCore.Mvc** module
- **OrchardCore.Application.Nancy.Targets**: Same as **OrchardCore.Application.Targets** but also references the **OrchardCore.Nancy** module
