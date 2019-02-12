using System;
using System.Collections.Generic;
using Dapper.Linq.Core.Predicates;

namespace Dapper.Linq.Predicates
{
    public class GetMultiplePredicateItem : IGetMultiplePredicateItem
    {
        public object Value { get; set; }
        public Type Type { get; set; }
        public IList<ISort> Sort { get; set; }
    }
}