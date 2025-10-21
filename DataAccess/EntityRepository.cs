using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    public class StudentsContext : DbContext
    {
        public StudentsContext() : base("DefaultConnection")
        {
        }
        public DbSet<Student> Students { get; set; }
    }
    public class EntityRepository : IRepository
    {
        public bool Create(Student student)
        {
            try
            {
                using (var context = new StudentsContext())
                {
                    context.Students.Add(student);
                    return context.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var context = new StudentsContext())
                {
                    var student = context.Students.FirstOrDefault(s => s.Id == id);
                    if (student != null)
                    {
                        context.Students.Remove(student);
                        return context.SaveChanges() > 0;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Student> ReadAll()
        {
            try
            {
                using (var context = new StudentsContext())
                {
                    return context.Students.ToList();
                }
            }
            catch
            {
                return new List<Student>();
            }
        }

        public Student ReadByID(int id)
        {
            try
            {
                using (var context = new StudentsContext())
                {
                    return context.Students.FirstOrDefault(s => s.Id == id);
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Student student)
        {
            try
            {
                using (var context = new StudentsContext())
                {
                    var existingStudent = context.Students.FirstOrDefault(s => s.Id == student.Id);
                    if (existingStudent != null)
                    {
                        existingStudent.Name = student.Name;
                        existingStudent.Speciality = student.Speciality;
                        existingStudent.Group = student.Group;
                        return context.SaveChanges() > 0;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
