using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace OracleDatabaseGateway
{
    abstract class OracleDatabaseInserter<T> : OracleGateway, I_Inserter<T>
    {
        object LockObject = new Object();
        public bool Insert(T itemToInsert)
        {
            lock (LockObject)
            {
                int NumRowsInserted = 0;

                OracleConnection Connection = GetDBConnection();

                OracleCommand Command = GetCommand(Connection);

                try
                {
                    NumRowsInserted = ExecuteInsertion(Command, itemToInsert);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }

                CloseDBConnection(Connection);

                if (NumRowsInserted > 0)
                {
                    return true;
                }
                else return false;
            }
        }

        protected abstract int ExecuteInsertion(OracleCommand Command, T itemToInsert);
        protected override abstract string SQLStatement();
    }
}
