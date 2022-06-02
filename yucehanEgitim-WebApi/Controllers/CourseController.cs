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
    public class CourseController : ApiController
    {

        private ICourseRepository repository;

        public CourseController()
        {
            repository = new CourseSqlImp();
        }

        [HttpGet]
        [Route("Course")]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCourses();
            return Ok(data);
        }

        [HttpGet]
        [Route("CourseByCatId/{catId}")]
        public List<Course> GetCategory(int catId)
        {
            return repository.getCourseBycatId(catId);
           
        }

        [HttpPost]
        [Route("Course")]
        public HttpResponseMessage PostCourse(Course Course)
        {
            var row = repository.AddCourse(Course);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hata! Kayid eklenemedi.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Kurs basariyla eklendi");
            }
        }

        [HttpGet]
        [Route("Course/{id}")]
        public Course GetCourse(int id)
        {
            return repository.GetCourseById(id);

        }

        [HttpPut]
        [Route("Course/{id}")]
        public HttpResponseMessage Put(int id, Course Course)
        {
            var row = repository.UpdateCourse(id, Course);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kurs id bulunamadi.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Kurs kaydi guncellendi!");
            }

        }

        [HttpDelete]
        [Route("Course/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var row = repository.DeleteCourse(id);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kategori id bulunamadi.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Kayit guncellendi!");
            }
        }
    }
}
