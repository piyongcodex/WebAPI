using Microsoft.Data.SqlClient;
using System.Data;

namespace CQRSpattern.Abstractions
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
