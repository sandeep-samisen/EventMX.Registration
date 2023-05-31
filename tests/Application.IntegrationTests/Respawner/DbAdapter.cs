using EventMX.Registration.Application.IntegrationTests.Respawner.Adapters;

namespace EventMX.Registration.Application.IntegrationTests.Respawner;
public class DbAdapter
{
    public static readonly IDbAdapter SqlServer = new SqlServerDbAdapter();
  //  public static readonly IDbAdapter Postgres = new PostgresDbAdapter();
    public static readonly IDbAdapter MySql = new MySqlAdapter();
  //  public static readonly IDbAdapter Oracle = new OracleDbAdapter();
  //  public static readonly IDbAdapter Informix = new InformixDbAdapter();
}