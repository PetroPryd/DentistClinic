using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClinicDatabase(this IServiceCollection services, string? connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException(
                    "Connection string 'ClinicDb' is missing. Set it with dotnet user-secrets (development) " +
                    "or the ConnectionStrings__ClinicDb environment variable (server).");

            services.AddDbContext<ClinicDbContext>(options =>
                options.UseNpgsql(connectionString)
                       .UseSnakeCaseNamingConvention());

            return services;
        }
    }
}
