using DTO;
using DTO.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usecases;

namespace Server.Presenters
{
    class TransactionLogPresenter : AbstractPresenter
    {
        public override IViewData ViewData
        {
            get
            {
                List<LogDTO> TransactionLog = ((LogDTO_List)DataToPresent).List;

                List<string> Lines = new List<string>();

                Lines.Add("\n Transaction Log");
                Lines.Add(string.Format("\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -12}", "Date", "Type", "ID", "Name", "Employee"));

                TransactionLog.ForEach(LogDTO => Lines.Add(DisplayUsageReport(LogDTO)));

                return new CommandLineViewData(Lines);
            }
        }

        private string DisplayUsageReport(LogDTO LogDTO)
        {
            return string.Format(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -12}",
                LogDTO.DateAdded,
                LogDTO.TypeOfTransaction,
                LogDTO.Item.ID,
                LogDTO.Item.Name,
                LogDTO.Item.EmployeeName);
        }
    }
}
