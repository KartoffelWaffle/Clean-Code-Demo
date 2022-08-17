using DTO;
using DTO.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usecases;

namespace CLI.Presenters
{
    class UsageReportPresenter : AbstractPresenter
    {
        public override IViewData ViewData
        {
            get
            {
                List<LogDTO> UsageReport = ((LogDTO_List)DataToPresent).List;

                List<string> Lines = new List<string>();

                Lines.Add("\n Personal Uasge Report");
                Lines.Add(string.Format("\t{0, -20} {1, -10} {2, -12} {3, -12}", "Date Taken", "ID", "Name", "Quantity"));

                UsageReport.ForEach(LogDTO => Lines.Add(DisplayUsageReport(LogDTO)));

                return new CommandLineViewData(Lines);
            }
        }

        private string DisplayUsageReport(LogDTO LogDTO)
        {
            return string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                LogDTO.DateAdded,
                LogDTO.Item.ID,
                LogDTO.Item.Name,
                LogDTO.ItemQuantity);
        }
    }
}
