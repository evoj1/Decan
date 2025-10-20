using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace ConsoleApp
{
    internal class Program
    {
        
        static Logic logic;
        static void Main(string[] args)
        {
            
            logic = new Logic();
            Console.WriteLine($"Репозиторий: {logic.GetRepositoryType()}\n");

            bool exit = true;

            while (exit)
            {
                PrintMenu();
                string number = Console.ReadLine();

                switch (number)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        DeleteStudent();
                        break;
                    case "3":
                        ShowAllStudents();
                        break;
                    case "4":
                        ShowHistogram();
                        break;
                    case "5":
                        exit = false;
                        break;
                    default: break;
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Удалить студента");
            Console.WriteLine("3. Показать всех студентов");
            Console.WriteLine("4. Показать гистограмму");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите пункт: ");
        }
        static void AddStudent()
        {
            logic.LoadData();
            Console.WriteLine("Введите ФИО студента: ");
            string name = Console.ReadLine();

            Console.WriteLine("Введите специальность: ");
            string speciality = Console.ReadLine();

            Console.WriteLine("Введите группу");
            string group = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(speciality) ||
                string.IsNullOrWhiteSpace(group))
            {
                Console.WriteLine("Все поля обязательны");
                return;
            }
            logic.AddStudent(name, speciality, group);
            Console.WriteLine("Студент добавлен");
        }
        static void DeleteStudent()
        {
            logic.LoadData();
            var students = logic.GetAllStudentsData();
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Console.WriteLine("Список студентов:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i][0]} - {students[i][1]} - {students[i][2]}");
            }

            Console.Write("Введите номер студента для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= students.Count)
            {
                var student = students[index - 1];
                bool removed = logic.RemoveStudent(student[0], student[1], student[2]);
                if (removed)
                {
                    Console.WriteLine("Студент удален");
                }
                else
                {
                    Console.WriteLine("Не удалось удалить студента");
                }
            }
            else
            {
                Console.WriteLine("Такого номера в списке нет");
            }
        }

        static void ShowAllStudents()
        {
            logic.LoadData();
            Console.WriteLine("Список всех студентов");

            var students = logic.GetAllStudentsData();
            if (students.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Console.WriteLine($"{"№",-3} {"ФИО",-30} {"Специальность",-20} {"Группа",-10}");
            Console.WriteLine(new string('-', 65));

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1,-3} {students[i][0],-30} {students[i][1],-20} {students[i][2],-10}");
            }
        }
        static void ShowHistogram()
        {
            logic.LoadData();
            Console.WriteLine("\nРаспределение студентов по специальностям");

            var distribution = logic.GetSpecialityDistribution();
            if (distribution.Count == 0)
            {
                Console.WriteLine("Студентов в списке нет");
                return;
            }

            int maxCount = distribution.Values.Max();
            int maxBarLength = 50;

            foreach (var item in distribution)
            {
                int barLength = (int)((double)item.Value / maxCount * maxBarLength);
                string bar = new string('█', barLength);
                Console.WriteLine($"{item.Key,-20} {bar} {item.Value}");
            }
        }
    }
}