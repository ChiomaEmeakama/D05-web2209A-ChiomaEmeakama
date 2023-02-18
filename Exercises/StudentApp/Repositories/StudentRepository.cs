using Microsoft.Data.SqlClient;
using StudentApp.Models;
using System;
using System.Configuration;
using System.Data;

namespace StudentApp.Repositories
{
    public class StudentRepository
    {
        private readonly string connectionString;

        public StudentRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SchoolDatabase"].ConnectionString;
        }

        public Student GetStudent(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, Name, DateOfBirth, CoursesPassed, Graduated, GraduationDate "
                + "FROM dbo.Students WHERE Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadNextStudent(reader);
            return null;
        }

        public bool UpdateStudent (Student student)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            // TODO
            //command.CommandText = $"SELECT Id, Name, DateOfBirth, CoursesPassed, Graduated, GraduationDate "
            //    + "FROM dbo.Students WHERE Id = @Id";
            //
            //command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            //
            //using SqlDataReader reader = command.ExecuteReader();
            //if (reader.Read())
            //    return ReadNextStudent(reader);
            return false;
        }

        private Student ReadNextStudent(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            DateTime dateOfBirth = reader.GetDateTime(2);
            int coursesPassed = reader.GetInt32(3);
            bool graduated = reader.GetBoolean(4);
            DateTime? graduationDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5);

            return new Student(id, name, dateOfBirth, coursesPassed, graduated, graduationDate);
        }
    }
}
