using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitecore.AspNet.RenderingEngine.Extensions;
using Sitecore.AspNet.RenderingEngine.Localization;
using Sitecore.LayoutService.Client.Extensions;
using System.Collections.Generic;
using System.Globalization;
using Sitecore.AspNet.ExperienceEditor;
using Sc102Project.Configuration;
using Sitecore.AspNet.Tracking;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
IConfiguration _config = builder.Configuration;
var services = builder.Services;
{
    var handler = _config.GetSection(DefaultHandlerOptions.Key).Get<DefaultHandlerOptions>();
    var experienceEditor = _config.GetSection(ExperienceEditorConfiguration.Key).Get<ExperienceEditorConfiguration>();
    var jssEditingSecret = _config.GetValue<string>(ExperienceEditorConfiguration.JssEditingSecretKey);

    services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

    services
        .AddSitecoreLayoutService()
        .AddHttpHandler(handler.Name, handler.Uri)
        .WithRequestOptions(request =>
        {
            foreach (var entry in handler.RequestDefaults)
                request.Add(entry.Key, entry.Value);
        })
        .AsDefaultHandler();

    services.AddSitecoreRenderingEngine(options =>
    {
        options
            //.AddModelBoundView<ContentBlock>("ContentBlock")
            .AddDefaultPartialView("_ComponentNotFound");
    })
        // In Experience Editor, relative links to resources of Rendering Host may render incorrectly,
        // Rendering Host therefore replaces such links with absolute ones, when sending the rendered layout back to Experience Editor.
        // By default, when generating absolute links, the current request from Experience Editor is used to get the Rendering Host URL.
        // You can change this behavior by setting your custom URL in ExperienceEditorOptions.
        // .WithExperienceEditor(options =>
        // {
        //     options.ApplicationUrl = new Uri("https://[your custom URL]");
        // })
        // More details see in ExperienceEditorOptions documentation.
        .WithExperienceEditor(options =>
        {
            options.Endpoint = experienceEditor.Endpoint;
            options.JssEditingSecret = jssEditingSecret;
                    //This is an example to show how we can target custom routes for the Experience Editor by adding custom mapping handlers.
            options.MapToRequest((sitecoreResponse, scPath, httpRequest) =>
                        httpRequest.Path = scPath + sitecoreResponse?.Sitecore?.Route?.DatabaseName);
        })
        .WithTracking();

    services.AddSitecoreVisitorIdentification(options =>
    {
        // Usually SitecoreInstanceHostName is same as Layout service but can be any Sitecore CD/CM instance which shares same AspNet session with Layout Service.
        // This Sitecore instance will be used for Visitor identification.
        var uriSetting = _config.GetSection("Analytics:SitecoreInstanceUri").Get<Uri>();
        options.SitecoreInstanceUri = uriSetting ?? new Uri("https://SitecoreInstanceHostName");
    });
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


