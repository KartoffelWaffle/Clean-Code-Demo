using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace OracleDatabaseGateway
{
    class OracleDBConnectionPool
    {
        private static string DATABASE_USERNAME = "";
        private static string DATABASE_PASSWORD = "";

        private static OracleDBConnectionPool instance = new OracleDBConnectionPool(5);

        private List<OracleConnection> availableConnections;
        private List<OracleConnection> busyConnections;
        private Object LockObject = new Object();

        private OracleDBConnectionPool(int sizeOfPool)
        {
            availableConnections = new List<OracleConnection>(sizeOfPool);
            busyConnections = new List<OracleConnection>(sizeOfPool);

            if (DATABASE_USERNAME == null || DATABASE_USERNAME.Equals(""))
            {
                Console.Write("Oracle database username: > ");
                DATABASE_USERNAME = Console.ReadLine();
                Console.Write("Oracle database_ password: > ");
                DATABASE_PASSWORD = Console.ReadLine();

            }

            for (int i = 0; i < sizeOfPool; i++)
            {
                availableConnections.Add(CreateConnection());
            }
        }

        ~OracleDBConnectionPool()
        {
            foreach (OracleConnection connection in availableConnections)
            {
                CloseConnection(connection);
            }
            availableConnections.Clear();

            foreach (OracleConnection connection in busyConnections)
            {
                CloseConnection(connection);
            }
            busyConnections.Clear();
        }

        public static OracleDBConnectionPool GetInstance()
        {
            return instance;
        }

        public bool CloseConnection(OracleConnection connection)
        {
            bool response = false;
            if (connection != null)
            {
                try
                {
                    connection.Close();
                    response = true;
                }
                catch (Exception e)
                {
                    throw new Exception("ERROR: closure of database connection failed", e);
                }
            }
            return response;
        }

        public OracleConnection CreateConnection()
        {
            OracleConnection connection = null;

            string CONNECTION_STRING
                = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))"
                    + "(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = stora)));User Id=" + DATABASE_USERNAME + ";Password=" + DATABASE_PASSWORD + ";";

            try
            {
                connection = new OracleConnection(CONNECTION_STRING);
                connection.Open();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: connection to database failed", e);
            }

            return connection;
        }

        public OracleConnection AquireConnection()
        {
            lock (LockObject)
            {
                if (availableConnections.Count > 0)
                {
                    OracleConnection connection = availableConnections[0];
                    availableConnections.RemoveAt(0);
                    busyConnections.Add(connection);
                    return connection;
                }
            }

            return null;
        }

        public void ReleaseConnection(OracleConnection connection)
        {
            lock (LockObject)
            {
                if (busyConnections.Contains(connection))
                {
                    busyConnections.Remove(connection);
                    availableConnections.Add(connection);
                }
            }
        }
    }
}
