using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace OracleDatabaseGateway
{
    abstract class OracleGateway
    {
        protected abstract string SQLStatement();

        public void CloseDBConnection(OracleConnection Connection)
        {
            OracleDBConnectionPool.GetInstance().ReleaseConnection(Connection);
        }

        public OracleConnection GetDBConnection()
        {
            return OracleDBConnectionPool.GetInstance().AquireConnection();
        }

        protected OracleCommand GetCommand(OracleConnection Connection)
        {
            return new OracleCommand
            {
                Connection = Connection,
                CommandText = SQLStatement(),
                CommandType = CommandType.Text
            };
        }
    }
}
