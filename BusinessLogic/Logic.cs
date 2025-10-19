using Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text.Json;
using System.Threading;

namespace BusinessLogic
{
    public class Logic
    {
        string filePath = @"C:\Users\evoj1\source\repos\Decan\BusinessLogic\students.json";
        List<Student> studentsData = new List<Student>();
        FileSystemWatcher watcher;
        bool suppressSave;

        public event EventHandler DataChanged;

        public Logic()
        {
            EnsureFileExists();
            LoadData();
            InitializeFileWatcher();
        }

        public void LoadData()
        {
            EnsureFileExists();
            var json = File.ReadAllText(filePath);
            List<Student> listFromFile = null;
            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    listFromFile = JsonSerializer.Deserialize<List<Student>>(json);
                }
                catch
                {
                    listFromFile = null;
                }
            }

            suppressSave = true;
            try
            {
                studentsData.Clear();
                if (listFromFile != null)
                {
                    foreach (var student in listFromFile)
                    {
                        studentsData.Add(student);
                    }
                }
            }
            finally
            {
                suppressSave = false;
            }

            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool RemoveStudent(string name, string speciality, string group)
        {
            if (studentsData == null)
            {
                Console.WriteLine("Ошибка: _studentsData равно null в RemoveStudent");
                return false;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(speciality) || string.IsNullOrEmpty(group))
            {
                Console.WriteLine("Ошибка: одно из полей (name, speciality, group) равно null или пустое");
                return false;
            }

            var toRemove = studentsData.FirstOrDefault(s => s != null &&
                                                            s.Name == name &&
                                                            s.Speciality == speciality &&
                                                            s.Group == group);
            if (toRemove != null)
            {
                studentsData.Remove(toRemove);
                SaveData();
                return true;
            }

            return false;
        }

        public List<string[]> GetAllStudentsData()
        {
            return studentsData
                .Where(s => s != null)
                .Select(s => new[] { s.Name ?? "", s.Speciality ?? "", s.Group ?? "" })
                .ToList();
        }

        public Dictionary<string, int> GetSpecialityDistribution()
        {
            return studentsData
                .Where(s => s != null && s.Speciality != null)
                .GroupBy(s => s.Speciality)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public bool AddStudent(string name, string speciality, string group)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(speciality) || string.IsNullOrEmpty(group))
            {
                return false;
            }

            var newStudent = new Student(name, speciality, group);
            studentsData.Add(newStudent);
            SaveData();
            return true;
        }

        private void SaveData()
        {
            if (suppressSave) return;
            File.WriteAllText(filePath, JsonSerializer.Serialize(studentsData));
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(filePath))
            {
                var dir = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.WriteAllText(filePath, "[]");
            }
        }

        private void InitializeFileWatcher()
        {
            var dir = Path.GetDirectoryName(filePath);
            var file = Path.GetFileName(filePath);
            watcher = new FileSystemWatcher(dir, file)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.FileName
            };
            watcher.Changed += OnFileChanged;
            watcher.Created += OnFileChanged;
            watcher.Renamed += OnFileChanged;
            watcher.EnableRaisingEvents = true;
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                Thread.Sleep(50);
                LoadData();
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {

            }
        }
    }
}