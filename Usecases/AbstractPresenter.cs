using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecases
{
    public abstract class AbstractPresenter
    {
        public IDTO DataToPresent { get; set; }

        public abstract IViewData 
            ViewData { get; }
    }
}
