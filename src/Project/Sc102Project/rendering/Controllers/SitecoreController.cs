using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model;

namespace Sc102Project.Controllers
{
    public class SitecoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
