using System;
using System.Collections.Generic;
using System.Reflection;
using Dapper.Linq.Core.Mapper;
using Dapper.Linq.Core.Sessions;
using Dapper.Linq.Core.Sql;

namespace Dapper.Linq.Core.Configuration
{
    public interface IDapperConfiguration
    {
        IDapperConfiguration WithDefaultConnectionStringNamed(string name);
        IDapperConfiguration FromAssembly(string name);
        IDapperConfiguration FromAssemblies(IEnumerable<Assembly> assemblies);
        IDapperConfiguration FromAssemblyContaining(Type assemblyType);
        IDapperConfiguration UseClassMapper(Type typeOfMapper);
        IDapperConfiguration UseSqlDialect(ISqlDialect dialect);
        IDapperConfiguration Build();

        List<Assembly> Assemblies { get; }

        Type DefaultMapper { get; }

        IDictionary<string, string> AllConnectionStrings { get; }

        string DefaultConnectionStringName { get; }
        ISqlDialect Dialect { get; }
        IClassMapper GetMap(Type entityType);
        IClassMapper GetMap<T>() where T : class;
        Guid GetNextGuid();
    }
}