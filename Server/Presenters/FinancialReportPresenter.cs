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
    class FinancialReportPresenter : AbstractPresenter
    {
        private float TotalCost = 0f;

        public override IViewData ViewData
        {
            get
            {
                List<LogDTO> FinancialReport = ((LogDTO_List)DataToPresent).List;

                List<string> Lines = new List<string>();

                Lines.Add("\n Financial Report");

                FinancialReport.ForEach(LogDTO => Lines.Add(DisplayIventoryReport(LogDTO)));
                FinancialReport.ForEach(LogDTO => CaculateTotalCost(LogDTO));

                Lines.Add(String.Format("Total price of all items: {0:C}", TotalCost));

                return new CommandLineViewData(Lines);
            }
        }

        private string DisplayIventoryReport(LogDTO LogDTO)
        {
            return string.Format(
                "{0}: Total price of item: {1:C}", 
                LogDTO.Item.Name,
                LogDTO.Item.ItemPrice);
        }

        private void CaculateTotalCost(LogDTO LogDTO) 
        {
            TotalCost += (LogDTO.Item.ItemPrice * LogDTO.Item.Quantity);
        }
    }
}
