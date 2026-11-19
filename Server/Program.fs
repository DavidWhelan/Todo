open Microsoft.AspNetCore.Builder
open Falco
open Vite.AspNetCore
open Controllers
open Microsoft.AspNetCore.StaticFiles

let endpoints = IndexController.endpoints

let bldr = WebApplication.CreateBuilder()

bldr.Services.AddViteServices() |> ignore

let wapp = bldr.Build()

let isDevelopment = wapp.Environment.EnvironmentName = "Development"

let provider = new FileExtensionContentTypeProvider()
provider.Mappings[".fs"] <- "text/javascript"

let staticFileoptions = new StaticFileOptions()
staticFileoptions.ContentTypeProvider <- provider

wapp
    .UseRouting()
    .UseIf(isDevelopment, DeveloperExceptionPageExtensions.UseDeveloperExceptionPage)
    .UseIf(not (isDevelopment), FalcoExtensions.UseFalcoExceptionHandler ErrorController.serverException)
    .UseIf(isDevelopment, WebSocketMiddlewareExtensions.UseWebSockets)
    .UseIf(isDevelopment, fun (appl: IApplicationBuilder) -> appl.UseViteDevelopmentServer(true))
    .Use(DefaultFilesExtensions.UseDefaultFiles)
    .UseIf(not (isDevelopment), fun (appl: IApplicationBuilder) -> appl.UseStaticFiles(staticFileoptions))
    .UseFalco(endpoints)
    .UseFalcoNotFound(ErrorController.notFound)
    .Run()
