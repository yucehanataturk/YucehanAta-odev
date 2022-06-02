using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yucehanEgitim.Models
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int id);
        int AddCourse(Course Course);
        int UpdateCourse(int id, Course Course);
        int DeleteCourse(int id);

        List<Course> getCourseBycatId(int catid);


    }
}