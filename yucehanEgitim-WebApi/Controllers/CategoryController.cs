using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using yucehanEgitim.Models;

namespace yucehanEgitim.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {

        private ICategoryRepository repository;

        public CategoryController()
        {
            repository = new CategorySqlImp();
        }

        [HttpGet]
        [Route("category")]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategories();
            return Ok(data);
        }

        [HttpPost]
        [Route("category")]
        public HttpResponseMessage PostCategory(Category category)
        {
            var row = repository.AddCategory(category);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hata! Yeni kayit eklenemedi.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Kurs kaydi eklendi!");
            }
        }


        [HttpGet]
        [Route("category/{id}")]
        public Category GetCategory(int id)
        {
            return repository.GetCategoryById(id);

        }

        [HttpPut]
        [Route("category/{id}")]
        public HttpResponseMessage Put(int id, Category category)
        {
            var row = repository.UpdateCategory(id, category);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kurs id bulunamadi!");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Kurs kaydi guncellendi!");
            }

        }

        [HttpDelete]
        [Route("category/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var row = repository.DeleteCategory(id);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kategori id bulunamadi!");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Kayit guncellendi!");
            }
        }
    }
}
