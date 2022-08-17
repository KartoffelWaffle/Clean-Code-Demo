using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using DTO;
using DTO.Builder;

namespace OracleDatabaseGateway
{
    class GetEmployee : OracleDatabaseRetriever<IDTO>
    {
        private string EmployeeName;

        public GetEmployee(string EmployeeName)
        {
            this.EmployeeName = EmployeeName;
        }

        protected override string SQLStatement()
        {
            return "SELECT EMPLOYEE_ID, EMPLOYEE_NAME FROM EMPLOYEE WHERE EMPLOYEE_NAME = :EmployeeName";
        }

        protected override IDTO ExecuteRetrieval(OracleCommand Command)
        {
            IDTO EmployeeDTO = new NullDTO();

            try
            {
                Command.Prepare();
                Command.Parameters.Add(":EmployeeName", EmployeeName);
                OracleDataReader DataReader = Command.ExecuteReader();

                if (DataReader.Read())
                {
                    EmployeeDTO =
                        new EmployeeDTO_Builder()
                        .WithID(DataReader.GetInt32(0))
                        .WithName(DataReader.GetString(1))
                        .Build();
                }

                DataReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Employee Retreival failed", e);
            }

            return EmployeeDTO;
        }
    }
}
