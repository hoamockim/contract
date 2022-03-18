using Entities;
using Microsoft.EntityFrameworkCore;

namespace Contract {

    public static class ContextExtension {
        public static void AddDataContext<T>(this IServiceCollection service, Action<DbContextOptionsBuilder> options) where T: DbContext {
            service.AddScoped<DataContext>();
        }
    }
}