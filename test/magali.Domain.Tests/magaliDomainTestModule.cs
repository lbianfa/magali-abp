using Volo.Abp.Modularity;

namespace magali;

[DependsOn(
    typeof(magaliDomainModule),
    typeof(magaliTestBaseModule)
)]
public class magaliDomainTestModule : AbpModule
{

}
