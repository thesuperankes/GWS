using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWS.Models.ApiResponse
{
    public class ApiResponse
    {
        public string Msg { get; set; }
        public bool Error { get; set; }
        public int Code { get; set; }
    }
}
