using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace magali.Data;

/* This is used if database provider does't define
 * ImagaliDbSchemaMigrator implementation.
 */
public class NullmagaliDbSchemaMigrator : ImagaliDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
