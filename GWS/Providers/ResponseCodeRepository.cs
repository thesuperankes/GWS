using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWS.Models;
using GWS.Repository;

namespace GWS.Providers
{
    public class ResponseCodeRepository : IResponseCodeRepository
    {
        private gwsContext db = new gwsContext();

        public ResponseCode GetResponseByCode(int code)
        {
            var data = db.ResponseCode.FirstOrDefault(s => s.Code == code);

            return data;
        }
    }
}
