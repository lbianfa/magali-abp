using Volo.Abp.Modularity;

namespace magali;

public abstract class magaliApplicationTestBase<TStartupModule> : magaliTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
