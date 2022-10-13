using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNet.RenderingEngine;
using Sitecore.AspNet.RenderingEngine.Filters;
using Sitecore.LayoutService.Client.Exceptions;
using Sitecore.LayoutService.Client.Response.Model;
using Sc102Project.Project.Sc102Project.Rendering.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Sc102Project.Project.Sc102Project.Rendering.Controllers
{
    public class SitecoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
