using System.Collections.Generic;
using Dapper.Linq.Core.Sql;

namespace Dapper.Linq.Core.Predicates
{
    public interface IPredicate
    {
        string GetSql(ISqlGenerator sqlGenerator, IDictionary<string, object> parameters);
    }
}