using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.DB.DBOperations;
using MyApp.Models;

namespace MyApp.DB.DBOperations
{
    public class CourseRepository
    {

        public int AddCourse(CourseModel model)
        {
            using (var context = new sumatrain_dbEntities())
            {
                course cou = new course()
                {
                    CourseId = model.CourseId,
                    CourseName = model.CourseName,
                    Fees = model.Fees
                };
                context.courses.Add(cou);

                context.SaveChanges();

                return cou.CourseId;
            }
        }
        public List<CourseModel> GetAllCourses()
        {
            using (var context = new sumatrain_dbEntities())
            {
                var result = context.courses.Select(x => new CourseModel()
                {
                    CourseId = x.CourseId,
                    CourseName = x.CourseName,
                    Fees = x.Fees
                }).ToList();

                return result;
            }
        }
        public CourseModel GetCourse(int Courseid)
        {
            using (var context = new sumatrain_dbEntities())
            {
                var result = context.courses
                    .Where(x => x.CourseId == Courseid)
                    .Select(x => new CourseModel()
                    {
                        CourseId = x.CourseId,
                        CourseName = x.CourseName,
                        Fees = x.Fees
                    }).FirstOrDefault();
                return result;
            }
        }

        public bool UpdateCourse(int CourseId, CourseModel model)
        {
            using (var context = new sumatrain_dbEntities())
            {
                var course = context.courses.FirstOrDefault(x => x.CourseId == CourseId);
                if (course!=null)
                {
                    course.CourseName = model.CourseName;
                    course.Fees = model.Fees;
                }
                context.Entry(course).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }


        public bool CourseDelete(int CourseId)
        {
            using (var context = new sumatrain_dbEntities())
            {
                var course = new course()
                {
                    CourseId = CourseId
                };
                context.Entry(course).State = System.Data.Entity.EntityState.Deleted;

                //context.students.Remove(course);
                context.SaveChanges();
            }
            return false;
        }

    }
}
