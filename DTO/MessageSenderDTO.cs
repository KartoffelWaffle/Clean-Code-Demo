using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class MessageSenderDTO : IDTO
    {
        public string Message { get; }

        public MessageSenderDTO(string Message)
        {
            this.Message = Message;
        }
    }
}
