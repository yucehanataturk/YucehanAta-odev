using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yucehanEgitim.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public DateTime publicationYear { get; set; }
        public string CourseDescription { get; set; }
        public int Price { get; set; }
        public int CoursePosition { get; set; }
        public Boolean CourseStatus { get; set; }
        public string imageName { get; set; }
        public string author { get; set; }
        public int catId { get; set; }

        public Course() { }

        public Course(string Title, DateTime publicationYear, string CourseDescription, int price, int CoursePosition , Boolean CourseStatus, string imageName, string author, int catId)
        {
            this.Title = Title;
            this.publicationYear = publicationYear;
            this.CourseDescription = CourseDescription;
            this.Price = price;
            this.CoursePosition = CoursePosition;
            this.CourseStatus = CourseStatus;
            this.imageName = imageName;
            this.author = author;
            this.catId = catId;
        }
    }
}

