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
    public class AdminController : ApiController
    {

        private IAdminRepository repository;

        public AdminController()
        {
            repository = new AdminSqlImp();
        }

        [HttpGet]
        [Route("admin")]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllAdmins();
            return Ok(data);
        }
    }
}
