using Volo.Abp.Modularity;

namespace magali;

[DependsOn(
    typeof(magaliApplicationModule),
    typeof(magaliDomainTestModule)
)]
public class magaliApplicationTestModule : AbpModule
{

}
