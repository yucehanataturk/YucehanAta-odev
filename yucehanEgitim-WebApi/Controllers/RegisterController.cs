using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yucehanEgitim.Models;
using System.Web.Http.Cors;

namespace yucehanEgitim.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegisterController : ApiController
    {
        private IRegisterRepository repository;

        public RegisterController()
        {
            repository = new RegisterSqlImp();
        }
        [HttpGet]
        public string Get()
        {
            return "test";
        }

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage PostRegister(Register user)
        {
            var row = repository.register(user);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "bir seyler ters gitti");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "basariyla giris yapildi");

            }
        }

        [HttpPost]
        [Route("login")]
        public string PostLogin(Register user)
        {
            return repository.login(user);
        }
    }
}
