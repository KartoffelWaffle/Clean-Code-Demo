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
    class GetInventoryReport : OracleDatabaseRetriever <List<ItemDTO>>
    {

        protected override string SQLStatement()
        {
            return "SELECT ITEM_ID, ITEM_NAME, ITEM_QUANTITY FROM STOCK WHERE ITEM_QUANTITY > 0";
        }

        protected override List<ItemDTO> ExecuteRetrieval(OracleCommand Command)
        {
            List<ItemDTO> UsageReportList = new List<ItemDTO>();

            try
            {
                Command.Prepare();
                OracleDataReader DataReader = Command.ExecuteReader();

                while (DataReader.Read())
                {
                    UsageReportList.Add(
                        new ItemDTO_Builder()
                        .WithID(DataReader.GetInt32(0))
                        .WithName(DataReader.GetString(1))
                        .WithQuantity(DataReader.GetInt32(2))
                        .Build());
                }

                DataReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Inventory report Retreival failed" + e.Message);
            }

            return UsageReportList;
        }
    }
}
