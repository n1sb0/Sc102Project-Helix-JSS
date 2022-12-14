using System.Collections.Generic;
using Sitecore.Data.Items;

namespace Sc102Project.Feature.Navigation.Models
{
    public class Header
    {
        public Item HomeItem { get; set; }
        public string HomeUrl { get; set; }
        public IList<NavigationItem> NavigationItems { get; set; }
    }
}