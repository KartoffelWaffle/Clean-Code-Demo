using DTO;
using DTO.Builder;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    class GetTransactionLog : OracleDatabaseRetriever<List<LogDTO>>
    {
        protected override string SQLStatement()
        {
            return "SELECT TRANSACTION_ID, STOCK.ITEM_ID, STOCK.ITEM_NAME, TYPE_OF_TRANSACTION, STOCK.ITEM_PRICE, QUANTITY, EMPLOYEE_NAME, DATE_ADDED FROM TRANSACTION_LOG LEFT JOIN STOCK ON TRANSACTION_LOG.ITEM_ID = STOCK.ITEM_ID";
        }

        protected override List<LogDTO> ExecuteRetrieval(OracleCommand Command)
        {
             List<LogDTO> LogList = new List<LogDTO>();

            try
            {
                Command.Prepare();
                OracleDataReader DataReader = Command.ExecuteReader();

                while (DataReader.Read())
                {
                    ItemDTO Item =
                        new ItemDTO_Builder()
                        .WithID(DataReader.GetInt32(1))
                        .WithName(DataReader.GetString(2))
                        .WithItemPrice(DataReader.GetFloat(4))
                        .WithQuantity(DataReader.GetInt32(5))
                        .WithEmployeeName(DataReader.GetString(6))
                        .Build();
                    LogList.Add(
                        new LogDTO_Builder()
                        .WithTransactionID(DataReader.GetInt32(0))
                        .WithTypeOfTransaction(DataReader.GetString(3))
                        .WithItem(Item)
                        .WithDateAdded(DataReader.GetDateTime(7))
                        .Build());
                }

                DataReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Retrieval of transaction log failed", e);
            }

            return LogList;
        }
    }
}
