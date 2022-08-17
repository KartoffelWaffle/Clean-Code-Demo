using DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    class InsertEmployee : OracleDatabaseInserter<EmployeeDTO>
    {
        protected override int ExecuteInsertion(OracleCommand Command, EmployeeDTO EmployeeToInsert)
        {
            Command.Prepare();
            Command.Parameters.Add(":id", EmployeeToInsert.ID);
            Command.Parameters.Add(":name", EmployeeToInsert.Name);
            int NumRowsAffected = Command.ExecuteNonQuery();

            if (NumRowsAffected != 1)
            {
                throw new Exception("Could not insert Employee");
            }
            return NumRowsAffected;
        }

        protected override string SQLStatement()
        {
            return "INSERT INTO EMPLOYEE (EMPLOYEE_ID, EMPLOYEE_Name) VALUES (:id, :name)";
        }
    }
}
