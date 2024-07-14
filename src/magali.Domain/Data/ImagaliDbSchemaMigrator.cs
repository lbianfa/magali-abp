using System.Threading.Tasks;

namespace magali.Data;

public interface ImagaliDbSchemaMigrator
{
    Task MigrateAsync();
}
