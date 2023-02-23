using EmployeeExam.Domain.Entities;

namespace EmployeeExam.Persistence.Repositories
{
    public class EmployeeRepository
    {
        public EmployeeRepository()
        {
            // TODO
        }

        public Employee GetEmployee(int id)
        {
            // TODO
            return null;
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
