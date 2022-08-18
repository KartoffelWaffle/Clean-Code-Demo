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
    class InventoryReportPresenter : AbstractPresenter
    {
        public override IViewData ViewData
        {
            get
            {
                List<ItemDTO> InventoryReport = ((ItemDTO_List)DataToPresent).List;

                List<string> Lines = new List<string>();

                Lines.Add("\n All Items");
                Lines.Add(string.Format("\t{0, -4} {1, -20} {2, -20}", "ID", "Name", "Quantity"));

                InventoryReport.ForEach(ItemDTO => Lines.Add(DisplayIventoryReport(ItemDTO)));

                return new CommandLineViewData(Lines);
            }
        }

        private string DisplayIventoryReport(ItemDTO ItemDTO)
        {
            return string.Format(
                "\t{0, -4} {1, -20} {2, -20}",
                ItemDTO.ID,
                ItemDTO.Name,
                ItemDTO.Quantity);
        }
    }
}
