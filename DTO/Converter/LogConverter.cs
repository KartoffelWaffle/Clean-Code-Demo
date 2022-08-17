using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Builder;
using DTO.Builder;

namespace DTO.Converter
{
    public class LogConverter : DTOConverter<LogDTO, Log>
    {
        public Log ConvertDTOToEntity(LogDTO LogDTO)
        {
            return
                new LogBuilder()
                .WithTransactionID(LogDTO.TransactionID)
                .WithTypeOfTransaction(LogDTO.TypeOfTransaction)
                .WithItem(new ItemConverter().ConvertDTOToEntity(LogDTO.Item))
                .WithDateAdded(LogDTO.DateAdded)
                .Build();
        }

        public LogDTO ConvertEntityToDTO(Log Log)
        {
            return
                new LogDTO_Builder()
                .WithTransactionID(Log.TransactionID)
                .WithTypeOfTransaction(Log.TypeOfTransaction)
                .WithItem(new ItemConverter().ConvertEntityToDTO(Log.Item))
                .WithDateAdded(Log.DateAdded)
                .Build();
        }
    }
}
