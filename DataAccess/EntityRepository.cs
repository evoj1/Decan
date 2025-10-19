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
        public StudentsContext() : base("DefualtConnection")
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
            throw new NotImplementedException();
        }

        public List<Student> ReadAll()
        {
            try
            {
                using (var context = new StudentsContext())
                {
                    return context.Students.FirstOrDefault(s => s.ID == id);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student ReadByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
