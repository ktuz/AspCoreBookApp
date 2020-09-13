using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data.Helpers
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }

}
