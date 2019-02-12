namespace Dapper.Linq.Core.Predicates
{
    public interface IBasePredicate : IPredicate
    {
        string PropertyName { get; set; }
    }
}