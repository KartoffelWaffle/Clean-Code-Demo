using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecases
{
    public interface IDatabaseGatewayFacade 
    {
    
        public bool InsertEmployee(EmployeeDTO EmployeeDTO);

        public bool InsertTransactionLog(LogDTO LogDTO);

        public EmployeeDTO GetEmployee(string EmployeeName);

        public ItemDTO GetItem(string ItemName);

        public bool InsertItemIntoStock(ItemDTO ItemDTO);
        public bool InsertQuantityIntoItem(ItemDTO ItemDTO);

        public bool UpdateQuantityFromStock(ItemDTO ItemDTO);

        public List<LogDTO> GetFinancialReport();

        public List<ItemDTO> GetInventoryReport();

        public List<LogDTO> GetTransactionLog();

        public List<LogDTO> GetUsageReport(string EmployeeName);

        public bool InitialiseDatabase();
    }
}
