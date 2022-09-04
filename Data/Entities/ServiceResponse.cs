using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uCarOk.Data.Entities
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public String Message { get; set; } = string.Empty;
    }
}