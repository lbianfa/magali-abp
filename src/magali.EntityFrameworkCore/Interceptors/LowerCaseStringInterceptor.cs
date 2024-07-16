
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace magali.Interceptors
{
    public class LowerCaseStringInterceptor : SaveChangesInterceptor
    {
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            ConvertStringsToLowerCase(eventData.Context);
            return base.SavedChanges(eventData, result);
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            ConvertStringsToLowerCase(eventData.Context);
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        private void ConvertStringsToLowerCase(DbContext context)
        {
            //var entries = context.ChangeTracker.Entries();

            //foreach (var entry in entries)
            //{
            //    if (entry.State == EntityState.Unchanged || entry.State == EntityState.Added || entry.State == EntityState.Modified)
            //    {
            //        var properties = entry.Properties
            //            .Where(p => p.Metadata.ClrType == typeof(string) && p.CurrentValue != null);

            //        foreach (var property in properties)
            //        {
            //            property.CurrentValue = property.CurrentValue.ToString().ToLowerInvariant();
            //        }
            //    }
            //}
        }
    }
}
