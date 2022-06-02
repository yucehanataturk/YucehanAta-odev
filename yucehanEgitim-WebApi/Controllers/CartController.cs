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
    public class CartController : ApiController
    {

        private ICartRepository repository;

        public CartController()
        {
            repository = new CartSqlImp();
        }

        [HttpGet]
        [Route("cart/{id}")]
        public Cart Get(int id)
        {
            return repository.GetCartById(id);
        }

        [HttpGet]
        [Route("cart")]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCarts();
            return Ok(data);
        }

        [HttpPost]
        [Route("cart")]
        public HttpResponseMessage PostCourse(Cart cart)
        {
            var row = repository.AddCart(cart);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hata! Kayid eklenemedi.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Kurs basariyla eklendi");
            }
        }


        [HttpDelete]
        [Route("cart/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var row = repository.DaleteCart(id);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kategori id bulunamadi.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Kayit guncellendi!");
            }
        }


        [HttpPut]
        [Route("cart/{id}")]
        public HttpResponseMessage Put(int id, Cart cart)
        {
            var row = repository.updateCart(id, cart);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kurs id bulunamadi.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Kurs kaydi guncellendi!");
            }

        }
    }
}
