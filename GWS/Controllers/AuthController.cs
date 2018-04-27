using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GWS.Models;
using GWS.Models.ApiResponse;
using GWS.Providers;
using GWS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GWS.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IUserRepository _userRepository;
        private IResponseCodeRepository _responseCodeRepository;

        // GET api/values/5
        [HttpGet]
        [Route("LoginUser")]
        public JsonResult Get([FromQuery]string username, [FromQuery] string password)
        {
            _userRepository = new UserRepository();
            _responseCodeRepository = new ResponseCodeRepository();

            var result = _userRepository.GetUserByUsername(username);
            if (result != null && result.Password == CalculateMD5Hash(password))
            {
                return Json(result);
            }

            var responseCode = _responseCodeRepository.GetResponseByCode(300);

            return Json(responseCode);

        }

        // POST api/values
        [HttpPost]
        [Route("RegisterUser")]
        public JsonResult Post([FromBody]User user)
        {
            _userRepository = new UserRepository();
            _responseCodeRepository = new ResponseCodeRepository();

            var hashPassword = CalculateMD5Hash(user.Password);

            var username = _userRepository.GetUserByUsername(user.Username);
            var email = _userRepository.GetUserByEmail(user.Email);
            var api = new ResponseCode();

            if (username != null)
            {
                api = _responseCodeRepository.GetResponseByCode(301);

                return Json(api);
            }
            if (email != null)
            {
                api = _responseCodeRepository.GetResponseByCode(302);
                return Json(api);
            }

            user.Password = hashPassword;

            var data = _userRepository.RegisterUser(user);

            if (data != null)
            {
                api = _responseCodeRepository.GetResponseByCode(200);

                return Json(api);
            }

            api = _responseCodeRepository.GetResponseByCode(400);

            return Json(api);


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

        public string CalculateMD5Hash(string input)

        {

            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));

            }

            return sb.ToString();
        }
    }
}