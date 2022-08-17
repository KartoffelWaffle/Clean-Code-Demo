using System;
using Usecases;
using DTO;
using System.Collections.Generic;

namespace OracleDatabaseGateway
{
    public class DatabaseGatewayFacade : IDatabaseGatewayFacade
    {

        public bool InsertEmployee(EmployeeDTO EmployeeDTO) 
        {
            return new InsertEmployee().Insert(EmployeeDTO);
        }

        public bool InsertTransactionLog(LogDTO LogDTO)
        {
            return new InsertTransactionLog().Insert(LogDTO);
        }

        public EmployeeDTO GetEmployee(string EmployeeName) 
        {
            return (EmployeeDTO) new GetEmployee(EmployeeName).Retrieve();
        }

        public ItemDTO GetItem(string ItemName) 
        {
            return (ItemDTO)new GetItem(ItemName).Retrieve();
        }

        public bool InsertItemIntoStock(ItemDTO ItemDTO)
        {
            return new InsertItemIntoStock().Insert(ItemDTO);
        }

        public bool InsertQuantityIntoItem(ItemDTO ItemDTO)
        {
            return new InsertQuantityIntoItem().Update(ItemDTO);
        }

        public bool UpdateQuantityFromStock(ItemDTO ItemDTO)
        {
            return new UpdateQuantityFromStock().Update(ItemDTO);
        }

        public List<LogDTO> GetFinancialReport()
        {
            return new GetFinancialReport().Retrieve();
        }

        public List<ItemDTO> GetInventoryReport()
        {
            return new GetInventoryReport().Retrieve();
        }

        public List<LogDTO> GetTransactionLog()
        {
            return new GetTransactionLog().Retrieve();
        }

        public List<LogDTO> GetUsageReport(string EmployeeName)
        {
            return new GetUsageReport(EmployeeName).Retrieve();
        }

        public bool InitialiseDatabase()
        {
            return new DatabaseInitialiser().Initialise();
        }
    }
}
