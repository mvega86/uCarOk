using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uCarOk.Domain.DTOs
{
    public class AddMechanicDTO
    {
        public String Name { get; set; } = String.Empty;
        public String LastName { get; set; } = String.Empty;
        public String PhoneNumber { get; set; } = String.Empty;
    }
}