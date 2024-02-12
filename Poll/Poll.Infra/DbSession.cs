using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Poll.Infra
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }

        public DbSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("Poll"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}