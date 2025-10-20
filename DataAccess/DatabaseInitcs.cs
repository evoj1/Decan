using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DatabaseInitcs : CreateDatabaseIfNotExists<StudentsContext>
    {
        protected override void Seed(StudentsContext context)
        {
            // Создаем тестовые данные (опционально)
            var testStudents = new[]
            {
                new Student { Name = "Иванов Иван Иванович", Speciality = "Программирование", Group = "ПР-21" },
                new Student { Name = "Петров Петр Петрович", Speciality = "Дизайн", Group = "ДЗ-20" },
                new Student { Name = "Сидорова Анна Викторовна", Speciality = "Программирование", Group = "ПР-21" }
            };

            foreach (var student in testStudents)
            {
                context.Students.Add(student);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
