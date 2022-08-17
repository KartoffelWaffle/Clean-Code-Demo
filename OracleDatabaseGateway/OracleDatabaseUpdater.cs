using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    abstract class OracleDatabaseUpdater<T> : OracleGateway, IUpdater<T>
    {
        object LockObject = new Object();
        public bool Update(T ItemToUpdate)
        {
            lock (LockObject)
            {
                int NumRowsUpdated = 0;

                OracleConnection Connection = GetDBConnection();

                OracleCommand Command = GetCommand(Connection);

                try
                {
                    NumRowsUpdated = ExecuteUpdate(Command, ItemToUpdate);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }

                CloseDBConnection(Connection);

                if (NumRowsUpdated > 0)
                {
                    return true;
                }
                else return false;
            }
        }


        protected abstract int ExecuteUpdate(OracleCommand Command, T ItemToUpdate);
        protected override abstract string SQLStatement();
    }
}
