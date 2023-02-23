using Microsoft.Data.SqlClient;
using PassportApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PassportApp.Repository
{
    public class PassportRepository
    {
        public readonly string connectionString;

        public PassportRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PassportsDatabase"].ConnectionString;
        }

        public Passport GetPassport(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, DateOfBirth, Country "
                                    + "FROM dbo.Passports WHERE Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadNextPassport(reader);
            return null;
        }


        public List<Passport> GetPassports()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, DateOfBirth, Country "
                                    + "FROM dbo.PassportDatabase";

            List<Passport> passports = new List<Passport>();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                passports.Add(ReadNextPassport(reader));

            return null;
        }


        public List<Passport> GetPassports(string firstName, string lastName)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, firstName, lastName, DateOfBirth, Country "
                                   + "FROM dbo.Passports "
                                   + "WHERE FirstName = @firstName and LastName = @lastName";

            command.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = firstName;
            command.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastName;

            using SqlDataReader reader = command.ExecuteReader();
            List<Passport> passports = new List<Passport>();
            while (reader.Read())
                passports.Add(ReadNextPassport(reader));
            return passports;
        }

        public Passport AddPassport(Passport passport)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO dbo.Passports "
                + "(FirstName, LastName, DateOfBirth, Country, DateCreated, DateUpdated)"
                + "OUTPUT INSERTED.Id "
                + "VALUES(@FirstName, @LastName, @DateOfBirth, @Country, @DateCreated, @DateUpdated)";

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = passport.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = passport.LastName;
            command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime2).Value = passport.DateOfBirth;
            command.Parameters.Add("@Country", SqlDbType.Int).Value = passport.Country;
            // command.Parameters.Add("@DateUpdated", SqlDbType.Bit).Value = passport.DateUpdated;


            DateTime now = DateTime.UtcNow;
            command.Parameters.Add("@DateCreated", SqlDbType.DateTime2).Value = now;
            command.Parameters.Add("@DateUpdated", SqlDbType.DateTime2).Value = now;

            int id = (int)command.ExecuteScalar();
            return new Passport(id, passport);
        }

        public bool UpdatePassport(Passport passport)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE dbo.Passports "
                + "SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Country = @Country"
                + "WHERE Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.Int).Value = passport.Id;
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = passport.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = passport.LastName;
            command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime2).Value = passport.DateOfBirth;
            command.Parameters.Add("@Country", SqlDbType.NVarChar).Value = passport.Country;
            command.Parameters.Add("@DateUpdated", SqlDbType.DateTime2).Value = DateTime.UtcNow;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool RemovePassport(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE dbo.Passports WHERE Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public List<Passport> GetPassports(DateTime minDateOfBirth, DateTime maxDateOfBirth)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, DateOfBirth, Country "
                                    + "FROM dbo.Passports "
                                    + "WHERE DateOfBirth BETWEEN @minDateOfBirth AND @maxDateOfBirth";

            command.Parameters.Add("@minDateOfBirth", SqlDbType.NVarChar).Value = minDateOfBirth ;
            command.Parameters.Add("@maxDateOfBirth", SqlDbType.NVarChar).Value = maxDateOfBirth;

            using SqlDataReader reader = command.ExecuteReader();
            List<Passport> students = new List<Passport>();
            while (reader.Read())
                students.Add(ReadNextPassport(reader));
            return students;
        }
        public Passport ReadNextPassport(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string firstName = reader.GetString(1);
            string lastName = reader.GetString(2);
            DateTime dateOfBirth = reader.GetDateTime(3);
            string country = reader.GetString(4);
            // DateTime dateCreated = reader.GetDateTime(5);
            // DateTime dateUpdated = reader.GetDateTime(6);

            return new Passport(id, firstName, lastName, dateOfBirth, country);
        }
    }
}



            