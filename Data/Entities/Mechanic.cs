using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uCarOk.Data.Entities.Base;

namespace uCarOk.Data.Entities
{
    public class Mechanic : EntityBase
    {
        public String Name { get; set; } = String.Empty;
        public String LastName { get; set; } = String.Empty;
        public String PhoneNumber { get; set; } = String.Empty;
    }
}