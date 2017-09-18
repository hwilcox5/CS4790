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
    }

    public class CourseAndSections
    {
        public Course course { get; set; }
        public List<Section> sections { get; set; }
    }
}