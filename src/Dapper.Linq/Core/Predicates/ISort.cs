namespace Dapper.Linq.Core.Predicates
{
    public interface ISort
    {
        string PropertyName { get; set; }
        bool Ascending { get; set; }
    }
}