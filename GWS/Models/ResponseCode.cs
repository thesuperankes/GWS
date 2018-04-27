using System;
using System.Collections.Generic;

namespace GWS.Models
{
    public partial class ResponseCode
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
