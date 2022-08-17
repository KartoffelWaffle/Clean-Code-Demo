using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO 
{
    interface DTOConverter<IDTO, IEntity>
    {
        IEntity ConvertDTOToEntity(IDTO dto);
        IDTO ConvertEntityToDTO(IEntity entity);
    }
}
