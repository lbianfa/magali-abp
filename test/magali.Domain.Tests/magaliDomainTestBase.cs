using Volo.Abp.Modularity;

namespace magali;

/* Inherit from this class for your domain layer tests. */
public abstract class magaliDomainTestBase<TStartupModule> : magaliTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
