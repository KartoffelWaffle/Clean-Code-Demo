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
    class GetFinancialReport : OracleDatabaseRetriever<List<LogDTO>>
    {
        protected override string SQLStatement()
        {
            return "SELECT STOCK.ITEM_ID, STOCK.ITEM_NAME, STOCK.ITEM_QUANTITY, STOCK.ITEM_PRICE FROM STOCK WHERE STOCK.ITEM_QUANTITY > 0";
        }

        protected override List<LogDTO> ExecuteRetrieval(OracleCommand Command)
        {
            List<LogDTO> UsageReportList = new List<LogDTO>();

            try
            {
                Command.Prepare();
                OracleDataReader DataReader = Command.ExecuteReader();

                while (DataReader.Read())
                {
                    ItemDTO Item =
                        new ItemDTO_Builder()
                        .WithID(DataReader.GetInt32(0))
                        .WithName(DataReader.GetString(1))
                        .WithItemPrice(DataReader.GetFloat(3))
                        .WithQuantity(DataReader.GetInt32(2))
                        .Build();
                    UsageReportList.Add(
                        new LogDTO_Builder()
                        .WithItem(Item)
                        .Build());
                }

                DataReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Usage report Retreival failed" + e.Message);
            }

            return UsageReportList;
        }
    }
}
