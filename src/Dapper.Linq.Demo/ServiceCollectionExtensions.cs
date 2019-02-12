using Dapper.Linq.Core;
using Dapper.Linq.Core.Configuration;
using Dapper.Linq.Core.Implementor;
using Dapper.Linq.Core.Repositories;
using Dapper.Linq.Core.Sessions;
using Dapper.Linq.Core.Sql;
using Dapper.Linq.Implementor;
using Dapper.Linq.Mapper;
using Dapper.Linq.MySql;
using Dapper.Linq.Repositories;
using Dapper.Linq.Sql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Dapper.Linq.Demo
{
    public static class ServiceCollectionExtensions
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            IDapperConfiguration getConfiguration(ILoggerFactory loggerFactory) =>
                 DapperConfiguration
                 .Use(GetAllConnectionStrings(configuration), loggerFactory)
                 .UseClassMapper(typeof(AutoClassMapper<>))
                 .UseSqlDialect(new MySqlDialect())
                 .WithDefaultConnectionStringNamed("DefaultConnectionString")
                 .FromAssemblies(GetEntityAssemblies())
                 .Build();

            services.AddSingleton(x => getConfiguration(x.GetRequiredService<ILoggerFactory>()));
            services.AddSingleton<IConnectionStringProvider, StaticConnectionStringProvider>();
            services.AddSingleton<IDapperSessionFactory, DapperSessionFactory>();
            services.AddScoped<IDapperSessionContext, DapperSessionContext>();
            services.AddScoped<ISqlGenerator, SqlGeneratorImpl>();
            services.AddScoped<IDapperImplementor, DapperImplementor>();
            services.AddScoped(typeof(IRepository<>), typeof(DapperRepository<>));
        }

        private static IDictionary<string, string> GetAllConnectionStrings(IConfiguration configuration)
        {
            var sections = configuration.GetSection("ConnectionStrings");

            return sections.GetChildren().ToDictionary(x => x.Key, x => x.Value);
        }

        private static IEnumerable<Assembly> GetEntityAssemblies()
        {
            var dllFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Directory.GetFiles(dllFolder, "*.dll")
                 .SelectMany(x => Assembly.LoadFrom(x).GetTypes())
                 .Where(x => typeof(IEntity).IsAssignableFrom(x))
                 .Select(x => x.Assembly)
                 .Distinct();
        }
    }
}
