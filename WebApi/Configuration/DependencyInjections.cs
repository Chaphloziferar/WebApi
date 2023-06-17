using WebApiBLL.Implementations.Sales;
using WebApiBLL.Interfaces.Sales;

namespace WebApi.Configuration
{
    public static class DependencyInjections
    {
        public static void AddBLL(this IServiceCollection services)
        {
            services.AddScoped<ISalesReasonBLL, SalesReasonBLL>();
        }
    }
}
