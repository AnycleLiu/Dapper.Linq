using Dapper.Linq.Core.Enums;

namespace Dapper.Linq.Core.Predicates
{
    public interface IComparePredicate : IBasePredicate
    {
        Operator Operator { get; set; }
        bool Not { get; set; }
    }
}