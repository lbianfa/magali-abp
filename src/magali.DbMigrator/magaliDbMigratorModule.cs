using magali.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace magali.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(magaliEntityFrameworkCoreModule),
    typeof(magaliApplicationContractsModule)
    )]
public class magaliDbMigratorModule : AbpModule
{
}
