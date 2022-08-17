using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Builder;
using DTO.Builder;
using Entities.State;

namespace DTO.Converter
{
    public class ItemConverter : DTOConverter<ItemDTO, Item>
    {
        public Item ConvertDTOToEntity(ItemDTO ItemDTO)
        {
            return new
                ItemBuilder()
                .WithID(ItemDTO.ID)
                .WithName(ItemDTO.Name)
                .WithQuantity(ItemDTO.Quantity)
                .WithEmployeeName(ItemDTO.EmployeeName)
                .WithDateCreated(ItemDTO.DateCreated)
                .WithState(ItemStateFactory.Create(ItemDTO.State))
                .Build();
        }

        public ItemDTO ConvertEntityToDTO(Item Item)
        {
            return new
                ItemDTO_Builder()
                .WithID(Item.ID)
                .WithName(Item.Name)
                .WithQuantity(Item.Quantity)
                .WithEmployeeName(Item.EmployeeName)
                .WithDateCreated(Item.DateCreated)
                .WithState(Item.State)
                .Build();
        }
    }
}
