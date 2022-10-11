﻿using Sc102Project.Feature.BasicContent.Models;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Sc102Project.Feature.BasicContent.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureBasicContent(this RenderingEngineOptions options)
        {
            options
                .AddModelBoundView<HeroBanner>("HeroBanner");
            return options;
        }
    }
}
