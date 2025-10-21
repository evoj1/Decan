using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DapperRepository : IRepository
    {
        private string _connectionString;
        public DapperRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public bool Create(Student student)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = "INSERT INTO Students (Name, Speciality, [Group]) VALUES (@Name, @Speciality, @Group)";
                    var result = connection.Execute(sql, student);
                    return result > 0;
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
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = "DELETE FROM Students WHERE Id = @Id";
                    var result = connection.Execute(sql, new { Id = id });
                    return result > 0;
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
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = "SELECT Id, Name, Speciality, [Group] FROM Students";
                    return connection.Query<Student>(sql).ToList();
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
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = "SELECT Id, Name, Speciality, [Group] FROM Students WHERE Id = @Id";
                    return connection.QueryFirstOrDefault<Student>(sql, new { Id = id });
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
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = "UPDATE Students SET Name = @Name," +
                        "Speciality = @Speciality," +
                        "[Group] = @Group WHERE Id = @Id";
                    var result = connection.Execute(sql, student);
                    return result > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
