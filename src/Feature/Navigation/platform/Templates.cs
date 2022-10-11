using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Sc102Project.Feature.Navigation
{
    public class Templates
    {
        public static class NavigationItem
        {
            public static readonly ID Id = new ID("{8C277C68-EC50-41AC-A7C9-62D3C91F36BE}");
            public static class Fields
            {
                public static readonly ID NavigationTitle = new ID("{736E4EC7-A839-4E39-8B15-7ADD6B3EB969}");
            }
        }

        public static class NavigationRoot
        {
            public static readonly ID Id = new ID("{40F4F475-2596-46F0-A838-B7578CC5BD80}");

            public static class Fields
            {
                public static readonly ID HeaderLogo = new ID("{A055FD0A-F488-403D-9E97-DE217E666F53}");
                public static readonly ID FooterCopyright = new ID("{53A3955A-AB96-4B9B-888C-C8E4D3C45CCF}");
            }
        }
    }
}