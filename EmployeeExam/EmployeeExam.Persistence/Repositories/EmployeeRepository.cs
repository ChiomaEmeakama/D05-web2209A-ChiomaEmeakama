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
            int id = reader.GetInt32(0);
            string firstName = reader.GetString(1);
            string lastName = reader.GetString(2);
            DateTime dateOfBirth = reader.GetDateTime(3);
            string jobTitle = reader.GetString(4);
            decimal hourlyWage = reader.GetDecimal(55);
            decimal hoursWorked = reader.GetDecimal(6);
            decimal hoursPaid = reader.GetDecimal(7);
            decimal paymentReceived = reader.GetDecimal(8);
            
            DateTime? graduationDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5);

            return new Employee(id, firstName, lastName, dateOfBirth, jobTitle,  hourlyWage, hoursWorked, hoursPaid, paymentReceived);
                         

            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, DateOfBirth, JobTitle ,HourlyWage, HoursWorked, HoursPaid, PaymentReceived, PaymentReceived "
                + "FROM dbo.EmployeeExamDatabase WHERE Id = @Id";

            using SqlDataReader reader = command.ExecuteReader();
            List<Employee> employee = new List<Employee>();
            while (reader.Read())
                employee.Add(ReadNextEmployee(reader));
            return employee;
        }

        public Employee AddEmployee(Employee employee)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO dbo.EmployeeExamDaatabase "
                + "(FirstName, LAstName, DateOfBirth, JobTitle, HourlyWage, HoursWorked, HoursPaid, PaymentReceived ) "
                + "OUTPUT INSERTED.Id "
                + "VALUES(@firstName, @lastName, @DateOfBirth, @JobTitle, @HourlyWage, @HoursWorked, @HoursPaid, @PaymentReceived)";

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = employee.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employee.LastName;
            command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime2).Value = employee.DateOfBirth;
            command.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = employee.JobTitle;
            command.Parameters.Add("@HourlyWage", SqlDbType.Int).Value = employee.HourlyWage;
            command.Parameters.Add("@HoursWorked", SqlDbType.Bit).Value = employee.HoursWorked;
            command.Parameters.Add("@HoursPaid", SqlDbType.DateTime2).Value = employee.HoursPaid;
            command.Parameters.Add("@PaymentDue", SqlDbType.DateTime2).Value = employee.PaymentDue;


            int id = (int)command.ExecuteScalar();
            return new Employee(id, employee);

        }

        public bool UpdateEmployee(Employee employee)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE dbo.Employee "
                + "SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, JobTitle = @JobTitle," +
                " HourlyWage = @HourlyWage, HoursWorked = @HoursWorked, HoursPaid = @HoursPaid, PaymentDue = @PaymentDue, "
                + "WHERE Id = @Id";

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = employee.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employee.LastName;
            command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime2).Value = employee.DateOfBirth;
            command.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = employee.JobTitle;
            command.Parameters.Add("@HourlyWage", SqlDbType.Int).Value = employee.HourlyWage;
            command.Parameters.Add("@HoursWorked", SqlDbType.Bit).Value = employee.HoursWorked;
            command.Parameters.Add("@HoursPaid", SqlDbType.DateTime2).Value = employee.HoursPaid;
            command.Parameters.Add("@PaymentDue", SqlDbType.DateTime2).Value = employee.PaymentDue;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
           
        }

        public bool RemoveEmployee(Employee employee)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE dbo.Employee" 
                + "SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, JobTitle = @JobTitle," +
                " HourlyWage = @HourlyWage, HoursWorked = @HoursWorked, HoursPaid = @HoursPaid, PaymentDue = @PaymentDue, "
                + "WHERE Id = @Id";

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = employee.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employee.LastName;
            command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime2).Value = employee.DateOfBirth;
            command.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = employee.JobTitle;
            command.Parameters.Add("@HourlyWage", SqlDbType.Int).Value = employee.HourlyWage;
            command.Parameters.Add("@HoursWorked", SqlDbType.Bit).Value = employee.HoursWorked;
            command.Parameters.Add("@HoursPaid", SqlDbType.DateTime2).Value = employee.HoursPaid;
            command.Parameters.Add("@PaymentDue", SqlDbType.DateTime2).Value = employee.PaymentDue;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool RemoveEmployee(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE dbo.Employee WHERE Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
