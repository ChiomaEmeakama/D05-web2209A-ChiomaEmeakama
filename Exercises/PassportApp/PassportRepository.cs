using Microsoft.Data.SqlClient;
using PassportApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PassportApp
{
    internal class PassportRepository
    {
        public readonly string connectionString;

        public Passport GetPassport(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, DateOfBirth, CoursesPassed, Graduated, GraduationDate "
                + "FROM dbo.Students WHERE Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadNextStudent(reader);
            return null;
        }
    }
}
