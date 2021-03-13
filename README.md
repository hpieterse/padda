# README #

Padda is a very simple 2D HTML game that is build using [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor). See it in action at [https://www.handsaw.co.za/padda](https://www.handsaw.co.za/padda)

## Did you know?  ##
Some interesting facts about the project

* The project is built to be a Progressive Web App.
* The application can run offline by using a service worker.
* Most of the game graphics are rendered using an HTML canvas
* For better performance, the canvas draw operations use unmarshalled calls from .Net to C#

## How do I get set up? ###

### Running the app
Because this application is built using Blazor, you can run it like any normal Blazor client-side Web Assembly project. The easiest is to use the .NET CLI

```
dotnet watch --project ./Handsaw.Padda/Handsaw.Padda.csproj run 
```

The repository does include launch settings for VSCode as well as build, watch, and publish tasks.

### Deployment instructions
There are also no special steps required for deployment. See the [documentation](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/?view=aspnetcore-5.0&tabs=visual-studio) on how to deploy a Blazor app.

## Contribution guidelines
If you want to contribute, let me know. Or otherwise, feel free to contribute by opening a pull requests
