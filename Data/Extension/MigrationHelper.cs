using ApplicationMember.Data.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationMember.Data.Extension
{
    public static class MigrationHelper
    {
        public static IApplicationBuilder MigrationDatabase(this IApplicationBuilder applicationBuilder)
        {
            using(var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                using(var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>())
                {
                    context.Database.Migrate();
                }
            }
            return applicationBuilder;
        }
    }
}
