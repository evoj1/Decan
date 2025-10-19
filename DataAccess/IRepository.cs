using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    public interface IRepository
    {
        bool Create(Student student);
        List<Student> ReadAll();
        Student ReadByID(int id);
        bool Delete(int id);
        bool Update(Student student);
    }
}
