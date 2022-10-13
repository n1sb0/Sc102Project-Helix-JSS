using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Sc102Project.Feature.BasicContent.Models
{
    internal class PromoCard
    {
        public TextField Title { get; set; }
        public TextField Subtitle { get; set; }
        public ImageField Image { get; set; }
        public HyperLinkField Link { get; set; }

    }
}
