using Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text.Json;
using System.Threading;
using DataAccess;

namespace BusinessLogic
{
    public class Logic
    {
        private IRepository _repository;
        public event EventHandler DataChanged;
        public Logic()
        {
            //_repository = new EntityRepository();
            _repository = new DapperRepository();
        }
        public string GetRepositoryType()
        {
            return _repository.GetType().Name;
        }
        public bool AddStudent(string name, string speciality, string group)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(speciality) ||
                string.IsNullOrWhiteSpace(group))
            {
                return false;
            }
            var newStudent = new Student
            {
                Name = name.Trim(),
                Speciality = speciality.Trim(),
                Group = group.Trim(),
            };
            var result = _repository.Create(newStudent);
            if (result)
            {
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
            return result;
        }
        public bool RemoveStudent(string name, string speciality, string group)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(speciality) ||
                string.IsNullOrWhiteSpace(group))
            {
                return false;
            }
            var students = _repository.ReadAll();
            var studentToRemove = students.FirstOrDefault(s => s.Name?.Trim().Equals(name.Trim(), StringComparison.OrdinalIgnoreCase) == true &&
            s.Speciality?.Trim().Equals(speciality.Trim(), StringComparison.OrdinalIgnoreCase) == true &&
            s.Group?.Trim().Equals(group.Trim(), StringComparison.OrdinalIgnoreCase) == true);
            if (studentToRemove != null)
            {
                var result = _repository.Delete(studentToRemove.ID);
                if (result)
                {
                    DataChanged?.Invoke(this, EventArgs.Empty) ;
                }
                return result;
            }
            return false;
        }
        public List<Student> GetAllStudents()
        {
            return _repository.ReadAll() ?? new List<Student>();
        }
        public List<string[]> GetAllStudentsData()
        {
            var students = GetAllStudents();
            return students.Select(s => new string[]
            {
                s.Name ?? "",
                s.Speciality ?? "",
                s.Group ?? ""
            }).ToList();
        }
        public Dictionary<string, int> GetSpecialityDistribution()
        {
            var students = GetAllStudents();
            return students
                .Where(s => !string.IsNullOrWhiteSpace(s.Speciality))
                .GroupBy(s => s.Speciality.Trim())
                .ToDictionary(g => g.Key, g => g.Count());
        }
        public void LoadData()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}