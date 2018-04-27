using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWS.Providers;
using GWS.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GWS.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IUserRepository _userRepository;

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            _userRepository = new UserRepository();

            var result = _userRepository.GetUserById(id);

            return Json(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
