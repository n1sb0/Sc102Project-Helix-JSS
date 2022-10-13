using Sc102Project.Feature.BasicContent.Models;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Sc102Project.Feature.BasicContent.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureBasicContent(this RenderingEngineOptions options)
        {
            options
                .AddModelBoundView<PromoCard>("PromoCard")
                .AddModelBoundView<SectionHeader>("SectionHeader")
                .AddModelBoundView<HeroBanner>("HeroBanner")
                .AddPartialView("PromoContainer")
                .AddPartialView("AccordionContainer");
            return options;
        }
    }
}
