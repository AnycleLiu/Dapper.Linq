using System.Collections.Generic;

namespace Dapper.Linq.Core.Predicates
{
    public interface IMultipleResultReader
    {
        IEnumerable<T> Read<T>();
    }
}