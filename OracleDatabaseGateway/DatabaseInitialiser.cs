using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    class DatabaseInitialiser
    {
        private readonly OracleCommand createEmployeeTable = new OracleCommand
        {
            CommandText = "CREATE TABLE EMPLOYEE(EMPLOYEE_ID int NOT NULL PRIMARY KEY, EMPLOYEE_NAME varchar(100) NOT NULL)",
            CommandType = CommandType.Text
        };

        private readonly OracleCommand createStockTable = new OracleCommand
        {
            CommandText = "CREATE TABLE STOCK(ITEM_ID int NOT NULL PRIMARY KEY, ITEM_NAME varchar(100) NOT NULL, ITEM_PRICE float NOT NULL, ITEM_QUANTITY int NOT NULL, ITEM_DATE_CREATED DATE NOT NULL)",
            CommandType = CommandType.Text
        };

        private readonly OracleCommand createTransactionLogTable = new OracleCommand
        {
            CommandText = "CREATE TABLE TRANSACTION_LOG(TRANSACTION_ID int NOT NULL PRIMARY KEY, ITEM_ID int NOT NULL, ITEM_NAME varchar(100) NOT NULL, TYPE_OF_TRANSACTION varchar(100) NOT NULL, QUANTITY int NOT NULL, EMPLOYEE_NAME varchar(100) NOT NULL, DATE_ADDED DATE NOT NULL)",
            CommandType = CommandType.Text
        };

        private readonly OracleCommand dropStockTable = new OracleCommand
        {
            CommandText = "DROP TABLE STOCK",
            CommandType = CommandType.Text
        };

        private readonly OracleCommand dropTransactionLogTable = new OracleCommand
        {
            CommandText = "DROP TABLE TRANSACTION_LOG",
            CommandType = CommandType.Text
        };

        private readonly OracleCommand dropEmployeeTable = new OracleCommand
        {
            CommandText = "DROP TABLE EMPLOYEE",
            CommandType = CommandType.Text
        };

        private readonly List<OracleCommand> commandSequence;

        public DatabaseInitialiser()
        {
            commandSequence = new List<OracleCommand>()
            {
                dropTransactionLogTable,
                dropEmployeeTable,
                dropStockTable,
                createStockTable,
                createEmployeeTable,
                createTransactionLogTable
            };
        }

        public bool Initialise()
        {
            OracleDBConnectionPool connectionPool = OracleDBConnectionPool.GetInstance();
            OracleConnection conn = connectionPool.AquireConnection();
            bool ExecuteOK = false;

            foreach (OracleCommand CommandSequence in commandSequence)
            {
                try
                {
                    CommandSequence.Connection = conn;
                    CommandSequence.ExecuteNonQuery();
                    ExecuteOK = true;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                    //ExecuteOK = false;
                }
            }

            connectionPool.ReleaseConnection(conn);
            return ExecuteOK;
        }
    }
}
