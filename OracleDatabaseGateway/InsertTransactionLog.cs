using DTO;
using Oracle.ManagedDataAccess.Client;
using OracleDatabaseGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    class InsertTransactionLog : OracleDatabaseInserter<LogDTO>
    {
        protected override int ExecuteInsertion(OracleCommand Command, LogDTO LogToInsert)
        {
            Command.Prepare();
            Command.Parameters.Add(":Transaction_ID", LogToInsert.TransactionID);
            Command.Parameters.Add(":ID", LogToInsert.Item.ID);
            Command.Parameters.Add(":Name", LogToInsert.Item.Name);
            Command.Parameters.Add(":TransactionType", LogToInsert.TypeOfTransaction);
            Command.Parameters.Add(":Quantity", LogToInsert.ItemQuantity);
            Command.Parameters.Add(":EmployeeName", LogToInsert.Item.EmployeeName);
            Command.Parameters.Add(":DateAdded", LogToInsert.DateAdded);
            int NumRowsAffected = Command.ExecuteNonQuery();

            if (NumRowsAffected != 1)
            {
                throw new Exception("Could not insert transaction");
            }
            return NumRowsAffected;
        }

        protected override string SQLStatement()
        {
            return "INSERT INTO TRANSACTION_LOG (TRANSACTION_ID, ITEM_ID, ITEM_NAME, TYPE_OF_TRANSACTION, QUANTITY, EMPLOYEE_NAME, DATE_ADDED) VALUES (:TransactionID, :ID, :Name, : TransactionType, :Quantity, :EmployeeName, :DateAdded)";
        }
    }
}
