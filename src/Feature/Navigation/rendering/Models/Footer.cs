﻿using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sc102Project.Feature.Navigation.Models
{
    public class Footer
    {
        [SitecoreComponentField]
        public string FooterText { get; set; }
    }
}
