using EmployeeExam.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace EmployeeExam.Persistence.Repositories
{
    public class EmployeeRepository
    {
        private readonly string connectionString;
        public EmployeeRepository()
        {
           connectionString = ConfigurationManager.ConnectionStrings["EmployeeExamDatabase"].ConnectionString;

        }

        public Employee GetEmployee(int id)
        {
            // TODO
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
                                                                                  
                                                                                  
            command.CommandText = $"SELECT Id, FirstName, LastName, DateOfBirth, JobTitle ,HourlyWage, HoursWorked, HoursPaid, PaymentReceived, PaymentReceived "
                + "FROM dbo.EmployeeExamDatabase WHERE Id = @Id";                  
                                                                       
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;   
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadNextEmployee(reader);

            return null;
        }

        private Employee ReadNextEmployee(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            // TODO
            return null;
        }

        public Employee AddEmployee(Employee employee)
        {
            // TODO
            return null;
        }

        public bool UpdateEmployee(Employee employee)
        {
            // TODO
            return false;
        }

        public bool RemoveEmployee(Employee employee)
        {
            return RemoveEmployee(employee.Id);
        }

        public bool RemoveEmployee(int id)
        {
            // TODO
            return false;
        }
    }
}
