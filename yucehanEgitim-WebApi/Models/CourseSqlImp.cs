using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace yucehanEgitim.Models
{
    public class CourseSqlImp : ICourseRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CourseSqlImp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }



        public List<Course> getCourseBycatId(int catid)
        {
            List<Course> Course = new List<Course>(); ;
            using (conn)
            {
                comm.CommandText = "Select Course.CourseId, Course.title, Course.publicationYear, Course.price, Course.CourseDesc, Course.CoursePosition, Course.CourseStatus, Course.imageName, Course.catId, Course.author from category inner join Course on category.catId=Course.catId where category.catId = " + catid + "";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["CourseId"]);
                    string title = dr["title"].ToString();
                    DateTime publicationYear = Convert.ToDateTime(dr["publicationYear"]);
                    int price = Convert.ToInt32(dr["price"]);
                    string desc = dr["CourseDesc"].ToString();
                    int position = Convert.ToInt32(dr["CoursePosition"]);
                    Boolean bStatus = Convert.ToBoolean(dr["CourseStatus"]);
                    string imgName = dr["imageName"].ToString();
                    int catId = Convert.ToInt32(dr["catId"]);
                    string author = dr["author"].ToString();
                     
                     
                    Course.Add(new Course(title, publicationYear, desc, price, position, bStatus, imgName, author, catId));

                }
            }
            return Course;
        }


        public int AddCourse(Course Course)
        {
            comm.CommandText = "insert into Course (Title, publicationYear, CourseDesc, price, CoursePosition, CourseStatus, imageName, author, catId) values (" + Course.ISBN + ", '" + Course.Title + "', '" + Course.publicationYear + "', '" + Course.CourseDescription + "', " + Course.Price + ", " + Course.CoursePosition + ", " + Convert.ToInt32(Course.CourseStatus) + ", '" + Course.imageName + "', '" + Course.author + "', " + Course.catId + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }

      

        public int DeleteCourse(int id)
        {
            int row;
            using (conn)
            {
                comm.CommandText = "delete from Course where CourseId = " + id + " ";
                comm.Connection = conn;
                conn.Open();
                row = comm.ExecuteNonQuery();
            }
            return row;
        }

        

        public List<Course> GetAllCourses()
        {
            List<Course> list = new List<Course>();
            comm.CommandText = "select * from Course";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["CourseId"]);
                string title = dr["title"].ToString();
                DateTime publicationYear = Convert.ToDateTime(dr["publicationYear"]);
                string desc = dr["CourseDesc"].ToString();
                int position = Convert.ToInt32(dr["CoursePosition"]);
                Boolean bStatus = Convert.ToBoolean(dr["CourseStatus"]);
                string imgName = dr["imageName"].ToString();
                string author = dr["author"].ToString();
                int price = Convert.ToInt32(dr["price"]);
                int catId = Convert.ToInt32(dr["catId"]);
                list.Add(new Course(title, publicationYear, desc, price,position, bStatus,imgName, author, catId));
            }
            conn.Close();
            return list;

            //    int CourseId, string Title, DateTime publicationYear, string CourseDescription, int price, int CoursePosition, bool CourseStatus, string imageName, string author, int catId)
            //
        }

        

        public Course GetCourseById(int id)
        {
            Course Course = null;
            using (conn)
            {
                comm.CommandText = "Select * from Course where CourseId = " + id + "";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Course = new Course();
                    Course.CourseId = dr.GetInt32(0);
                    Course.Title = dr.GetString(1);
                    Course.publicationYear = dr.GetDateTime(2);
                    Course.Price = Convert.ToInt32(dr.GetDecimal(3));
                    Course.CourseDescription = dr.GetString(4);
                    Course.CoursePosition = dr.GetInt32(5);
                    Course.CourseStatus = dr.GetBoolean(6);
                    Course.imageName = dr.GetString(7);
                    Course.catId = dr.GetInt32(8);
                    Course.author = dr.GetString(9);


                }
            }
            return Course;
        }

         
        public int UpdateCourse(int id, Course Course)
        {
            int row;
            using (conn)
            {

                comm.Connection = conn;
                comm.CommandText = "Update Course set title='" + Course.Title + "',publicationYear='"+ Course.publicationYear + "', price='"+ Course.Price + "',CourseDesc='"+ Course.CourseDescription + "',CoursePosition='"+ Course.CoursePosition + "',CourseStatus='"+ Course.CourseStatus + "',imageName='"+ Course.imageName + "',catId='"+ Course.catId + "',author='"+ Course.author + "' where CourseId = " + id;
                conn.Open();
                row = comm.ExecuteNonQuery();

            }
            return row;
        }

        
    }
}