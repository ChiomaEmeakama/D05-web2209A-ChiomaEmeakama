using EmployeeExam.Domain.Exceptions;

namespace EmployeeExam.Domain.Entities
{
    public class Employee
    {
        // TODO: Enforce encapsulation and business rules by:
        // Making property set accessors private, and/or
        // Manually defining set accessors to include validation (conditional validation)

        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
        public decimal HourlyWage { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HoursPaid { get; set; }
        public decimal PaymentReceived { get; set; }

        public string FullName
        {
            get
            {
                // TODO
                return null;
            }
        }

        public decimal HoursUnpaid
        {
            get
            {
                // TODO
                return 0;
            }
        }

        public decimal PaymentDue
        {
            get
            {
                // TODO
                return 0;
            }
        }

        public Employee(int id, Employee other)
            : this(id, other.FirstName, other.LastName, other.DateOfBirth, other.JobTitle, other.HourlyWage, other.HoursWorked, other.HoursPaid, other.PaymentReceived)
        { }

        /// <exception cref="ArgumentNullException">If first name, last name, or job title is null.</exception>
        /// <exception cref="EmployeeException">If first name, last name, or job title is empty or whitespace.</exception>
        /// <exception cref="EmployeeException">If date of birth is not in the past.</exception>
        /// <exception cref="EmployeeException">If hourly wage is negative.</exception>
        public Employee(string firstName, string lastName, DateTime dateOfBirth, string jobTitle, decimal hourlyWage)
            : this(id: 0, firstName, lastName, dateOfBirth, jobTitle, hourlyWage, hoursWorked: 0, hoursPaid: 0, paymentReceived: 0)
        { }

        /// <exception cref="ArgumentNullException">If first name, last name, or job title is null.</exception>
        /// <exception cref="EmployeeException">If first name, last name, or job title is empty or whitespace.</exception>
        /// <exception cref="EmployeeException">If date of birth is not in the past.</exception>
        /// <exception cref="EmployeeException">If hourly wage, hours worked, hours paid, or payment received is negative.</exception>
        public Employee(int id, string firstName, string lastName, DateTime dateOfBirth, string jobTitle, decimal hourlyWage, decimal hoursWorked, decimal hoursPaid, decimal paymentReceived)
        {
            // TODO: Validate that nullable arguments are not null, and otherwise throw an ArgumentNullException

            // TODO: Validate that all arguments are valid, and otherwise throw an EmployeeException with a clear message
            // Rule: First name must not be empty or whitespace.
            // Rule: Last name must not be empty or whitespace.
            // Rule: Job title must not be empty or whitespace.
            // Rule: Date of birth must be in the past.
            // Rule: Hourly wage must not be negative.
            // Rule: Hours worked must not be negative.
            // Rule: Hours paid must not be negative.
            // Rule: Payment received must not be negative.

            // TODO: Initialize instance variables and properties
        }

        /// <exception cref="EmployeeException">If additional hours worked is not positive.</exception>
        public void LogHours(decimal additionalHoursWorked)
        {
            // TODO: Validate that argument is valid, and otherwise throw an EmployeeException with a clear message
            // Rule: Additional hours worked must be positive.

            // TODO: If and only if the argument is valid, update the total number of hours worked to reflect the additional hours worked
        }

        /// <exception cref="EmployeeException">If raise percentage is not positive.</exception>
        public void GiveRaise(decimal raisePercentage)
        {
            // TODO: Validate that argument is valid, and otherwise throw an EmployeeException with a clear message
            // Rule: Raise percentage must be positive.

            // TODO: If and only if the argument is valid, calculate the raise amount and update the hourly wage to reflect the raise
        }

        public void PayAmountDue()
        {
            // TODO: Pay the employee for all unpaid hours by updating the number of hours paid and the total amount of payment received
        }
    }
}
