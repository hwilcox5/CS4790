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
            List<Course> course = db.courses.ToList();
            return course;
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

        public static void addCourse(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.courses.Add(course);
            db.SaveChanges();
        }

        public static void modifyCourseState(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void deleteCourseComfirmed(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(course).State = EntityState.Deleted;
            db.courses.Remove(course);
            db.SaveChanges();
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

        // To make a list of all the sections
        public static List<Section> getAllSections()
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            List<Section> sections = db.sections.ToList();
            return sections;
        }

        public static void addSection(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.sections.Add(section);
            db.SaveChanges();
        }

        public static void modifySectionState(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(section).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void deleteSectionComfirmed(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(section).State = EntityState.Deleted;
            db.sections.Remove(section);
            db.SaveChanges();
        }

        public static CourseAndSections getCourseAndSections(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            CourseAndSections courseAndSections = new CourseAndSections();

            courseAndSections.course = db.courses.Find(id);
            var sections = db.sections.Where(s =>
                s.courseNumber == courseAndSections.course.courseNumber);

            courseAndSections.sections = sections.ToList();
            return courseAndSections;
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
        [DisplayName("Section Datetime")]
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