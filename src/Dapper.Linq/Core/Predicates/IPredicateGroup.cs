using System.Collections.Generic;
using Dapper.Linq.Core.Enums;

namespace Dapper.Linq.Core.Predicates
{
    public interface IPredicateGroup : IPredicate
    {
        GroupOperator Operator { get; set; }
        IList<IPredicate> Predicates { get; set; }
    }
}