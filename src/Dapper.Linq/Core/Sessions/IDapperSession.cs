using System.Data;

namespace Dapper.Linq.Core.Sessions
{
    public interface IDapperSession : IDbConnection
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; set; }
    }
}
