using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    abstract class OracleDatabaseRetriever<T> : OracleGateway, IRetriever<T>
    {
        object LockObject = new Object();
        public T Retrieve()
        {
            lock (LockObject)
            {
                T item;

                OracleConnection Connection = GetDBConnection();

                OracleCommand Command = GetCommand(Connection);

                try
                {
                    item = ExecuteRetrieval(Command);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }

                CloseDBConnection(Connection);
                return item;
            }
        }

        protected abstract T ExecuteRetrieval(OracleCommand Command);
        protected override abstract string SQLStatement();
    }
}