using Sc102Project.Feature.Navigation.Models;
using Sitecore.Data.Items;

namespace Sc102Project.Feature.Navigation.Services
{
    public interface IHeaderBuilder
    {
        Header GetHeader(Item contextItem);
    }
}
