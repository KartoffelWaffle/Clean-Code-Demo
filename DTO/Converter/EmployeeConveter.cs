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
    public class EmployeeConveter : DTOConverter<EmployeeDTO, Employee>
    {
        public Employee ConvertDTOToEntity(EmployeeDTO EmployeeDTO)
        {
            return new
                EmployeeBuilder()
                .WithID(EmployeeDTO.ID)
                .WithName(EmployeeDTO.Name)
                .Build();
        }

        public EmployeeDTO ConvertEntityToDTO(Employee Employee)
        {
            return new
                EmployeeDTO_Builder()
                .WithID(Employee.ID)
                .WithName(Employee.Name)
                .Build();
        }
    }
}
