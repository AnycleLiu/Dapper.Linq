using Dapper.Linq.Core.Predicates;

namespace Dapper.Linq.Predicates
{
    public class Sort : ISort
    {
        public string PropertyName { get; set; }
        public bool Ascending { get; set; }
    }
}