using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CS4790A2.Models
{
    /*
     * 3a. Create model class
     */
    public class BasicSchool
    {
        // To make a list of all the courses
        public static List<Course> getAllCourses()
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.courses.ToList();
        }

        // To make a list of all the sections
        public static List<Section> getAllSections()
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.sections.ToList();
        }

        /// <summary>
        /// Gets the course by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Course getCourse(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            Course course = db.courses.Find(id);
            return course;
        }

        /// <summary>
        /// Gets the section by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Section getSection(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            Section section = db.sections.Find(id);
            return section;
        }
    }

    /*
     *3c. Create classes for each table in database 
     */
    [Table("Course")]
    public class Course
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Course Number")]
        public string courseNumber { get; set; }
        [DisplayName("Course Name")]
        public string courseName { get; set; }
        [DisplayName("Credit Hours")]
        [Range(0,4)]
        public int creditHours { get; set; }
        [DisplayName("Maximum Enrollment")]
        public int? maxEnrollment { get; set; }
    }

    [Table("Section")]
    public class Section
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Section ID")]
        public int sectionID { get; set; }
        [DisplayName("Section Number")]
        public int sectionNumber { get; set; }
        [DisplayName("Course Number")]
        public string courseNumber { get; set; }
        [DisplayName("Section Days")]
        public string sectionDays { get; set; }
        [DisplayName("Section Time")]
        public DateTime sectionTime { get; set; }
    }

    /*
     * 4. Create the DbContext Class
     */
    public class BasicSchoolDbContext : DbContext
    {
        public DbSet<Course> courses { get; set; }
        public DbSet<Section> sections { get; set; }
    }
}