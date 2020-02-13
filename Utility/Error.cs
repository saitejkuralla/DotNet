using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Utility
{
    public class Error
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Path { get; set; }

    }
}
