using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tutorial9.Middlewares
{
    public class ErrorInfo
    {
        public string Message { get; set; }

        public DateTime Date { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
