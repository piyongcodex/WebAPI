using System.Data;

namespace CQRSpattern.Infrastructure.Common.Interface
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
