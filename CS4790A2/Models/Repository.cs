using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS4790A2.Models
{
    public class Repository
    {
        /// <summary>
        /// Gets the course by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Course getCourse(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            Course course = BasicSchool.getCourse(id);
            return course;
        }

        public static List<Course> getAllCourses()
        {
            List<Course> courses = BasicSchool.getAllCourses();
            return courses;
        }

        public static void addCourse(Course course)
        {
            BasicSchool.addCourse(course);
        }

        public static void modifyCourseState(Course course)
        {
            BasicSchool.modifyCourseState(course);
        }

        public static void removeCourse(Course course)
        {
            BasicSchool.deleteCourseComfirmed(course);
        }

        /// <summary>
        /// Gets the section by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Section getSection(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            Section section = BasicSchool.getSection(id);
            return section;
        }

        public static List<Section> getAllSections()
        {
            List<Section> sections = BasicSchool.getAllSections();
            return sections;
        }

        public static void addSection(Section section)
        {
            BasicSchool.addSection(section);
        }

        public static void modifySectionState(Section section)
        {
            BasicSchool.modifySectionState(section);
        }

        public static void removeSection(Section section)
        {
            BasicSchool.deleteSectionComfirmed(section);
        }

        public static CourseAndSections getCourseAndSections(int? id)
        {
            CourseAndSections courseAndSections = BasicSchool.getCourseAndSections(id);
            return courseAndSections;
        }
    }

    public class CourseAndSections
    {
        public CourseAndSections()
        {

        }
        public Course course { get; set; }
        public List<Section> sections { get; set; }
    }
}