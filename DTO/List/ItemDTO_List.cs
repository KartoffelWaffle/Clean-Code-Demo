using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.List
{
    [Serializable]
    public class ItemDTO_List : IDTO
    {
        public List<ItemDTO> List { get; }

        public ItemDTO_List(List<ItemDTO> List)
        {
            this.List = List;
        }
    }
}
