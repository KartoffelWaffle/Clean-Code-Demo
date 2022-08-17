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
    class GetUsageReport : OracleDatabaseRetriever<List<LogDTO>>
    {
        private string EmployeeName;

        public GetUsageReport(string EmployeeName)
        {
            this.EmployeeName = EmployeeName;
        }

        protected override string SQLStatement()
        {
            return "SELECT ITEM_ID, ITEM_NAME, TYPE_OF_TRANSACTION, DATE_ADDED, EMPLOYEE_NAME, QUANTITY FROM TRANSACTION_LOG WHERE EMPLOYEE_NAME = :EmployeeName";
        }

        protected override List<LogDTO> ExecuteRetrieval(OracleCommand Command)
        {
            List<LogDTO> UsageReportList = new List<LogDTO>();

            try
            {
                Command.Prepare();
                Command.Parameters.Add(":EmployeeName", EmployeeName);
                OracleDataReader DataReader = Command.ExecuteReader();

                while (DataReader.Read())
                {
                    ItemDTO Item =
                        new ItemDTO_Builder()
                        .WithID(DataReader.GetInt32(0))
                        .WithName(DataReader.GetString(1))
                        .WithEmployeeName(DataReader.GetString(4))
                        .Build();
                    UsageReportList.Add(
                        new LogDTO_Builder()
                        .WithItem(Item)
                        .WithTypeOfTransaction(DataReader.GetString(2))
                        .WithDateAdded(DataReader.GetDateTime(3))
                        .WithItemQuantity(DataReader.GetInt32(5))
                        .Build());
                }

                DataReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Usage report Retreival failed", e);
            }

            return UsageReportList;
        }
    }
}
