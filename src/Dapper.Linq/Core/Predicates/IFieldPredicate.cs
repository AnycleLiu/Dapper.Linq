namespace Dapper.Linq.Core.Predicates
{
    public interface IFieldPredicate : IComparePredicate
    {
        object Value { get; set; }
    }
}