using Sitecore.Data.Items;

namespace Sc102Project.Feature.Navigation.Services
{
    public interface INavigationRootResolver
    {
        Item GetNavigationRoot(Item contextItem);
    }
}
