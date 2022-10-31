using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.DB.DBOperations;

namespace MyApp.DB.DBOperations
{
    public class StudentRepository
    {
        public int AddStudent(StudentModel model)
        {
            using (var context = new sumatrain_dbEntities())
            {
                student stu = new student()
                {
                    StudentName = model.StudentName,
                    Gender = model.Gender,
                    CourseId = model.CourseId
                };
                //context.students.Add(stu);
                context.Entry(stu).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return stu.RollNumber;
            }
        }

        public List<StudentModel> GetAllStudents()
        {
            using (var context = new sumatrain_dbEntities())
            {
                var result = context.students
                    .Select(x => new StudentModel()
                    {
                        RollNumber = x.RollNumber,
                        StudentName = x.StudentName,
                        Gender = x.Gender,
                        CourseId = x.CourseId
                    }).ToList();
                return result;
            }
        }


        public StudentModel GetStudent(int RollNumber)
        {
            using (var context = new sumatrain_dbEntities())
            {
                var result = context.students
                    .Where(x => x.RollNumber == RollNumber)
                    .Select(x => new StudentModel()
                    {
                        RollNumber = x.RollNumber,
                        StudentName = x.StudentName,
                        Gender = x.Gender,
                        CourseId = x.CourseId
                    }).FirstOrDefault();
                return result;
            }
        }

        public bool UpdateStudent(int RollNumber, StudentModel model)
        {
            using (var context = new sumatrain_dbEntities())
            {
                var student = context.students.FirstOrDefault(x => x.RollNumber == RollNumber);
                if (student != null)
                {
                    student.RollNumber = model.RollNumber;
                    student.StudentName = model.StudentName;
                    student.Gender = model.Gender;
                    student.CourseId = model.CourseId;
                }
                context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool StudentDelete(int RollNumber)
        {
            using (var context = new sumatrain_dbEntities())
            {
                var student = new student()
                {
                    RollNumber = RollNumber
                };
                context.Entry(student).State = System.Data.Entity.EntityState.Deleted;

                //context.students.Remove(student);
                context.SaveChanges();
            }
            return false;
        }
    }
}
