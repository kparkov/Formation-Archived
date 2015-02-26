using System;
using System.Data.SqlClient;

namespace Bit.Helpers.Console
{
    public class DatabaseHelpers
    {
        public void ForceDropConnections(string connectionString)
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(connectionString);
            RunHelpers run = new RunHelpers();

            run.SyncProcess(String.Format("sqlcmd -S {0} -U {1} -P {2} -Q \"ALTER DATABASE {3} SET OFFLINE WITH ROLLBACK IMMEDIATE;\"", csb.DataSource, csb.UserID, csb.Password, csb.InitialCatalog));
            run.SyncProcess(String.Format("sqlcmd -S {0} -U {1} -P {2} -Q \"ALTER DATABASE {3} SET ONLINE;\"", csb.DataSource, csb.UserID, csb.Password, csb.InitialCatalog));
        }

        public void DropDatabase(string connectionString)
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(connectionString);
            RunHelpers run = new RunHelpers();

            run.SyncProcess(String.Format("sqlcmd -S {0} -U {1} -P {2} -Q \"DROP DATABASE {3};\"", csb.DataSource, csb.UserID, csb.Password, csb.InitialCatalog));
        }
    }
}