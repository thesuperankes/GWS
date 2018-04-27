using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWS.Models;

namespace GWS.Repository
{
    public interface IResponseCodeRepository
    {
        ResponseCode GetResponseByCode(int code);
    }
}
