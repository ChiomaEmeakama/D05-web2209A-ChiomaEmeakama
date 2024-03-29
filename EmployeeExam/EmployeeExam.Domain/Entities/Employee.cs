﻿using Chevalier.Utility.ViewModels;
using EmployeeExam.Domain.Exceptions;
using System.ComponentModel;

namespace EmployeeExam.Domain.Entities
{
    public class Employee : ViewModel
    {
        // TODO: Enforce encapsulation and business rules by:
        // Making property set accessors private, and/or
        // Manually defining set accessors to include validation (conditional validation)

        private string lastName;
        private string firstName;
        private string jobTitle;
        public int Id { get; }
        public string FirstName
        {
            get
            {
                return FirstName;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                    NotifyPropertyChanged (nameof(FirstName));
                }
            }

        }
        
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                    NotifyPropertyChanged (nameof(LastName));
                }
            }
        }

        public string JobTitle
        {
            get
            {
                return jobTitle;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                    NotifyPropertyChanged (nameof(JobTitle));
                }
            }
        }

        
        public DateTime DateOfBirth { get; set; }
        public decimal HourlyWage { get; private set; }
        public decimal HoursWorked { get; private set; }
        public decimal HoursPaid { get; private set; }
        public decimal PaymentReceived { get; private set; }

        public string FullName => "FirstName" + "LastName";

        public decimal HoursUnpaid => HoursWorked - HoursPaid;

        public decimal PaymentDue => HoursUnpaid * HourlyWage;

        public Employee(int id, Employee other)
            : this(id, other.FirstName, other.LastName, other.DateOfBirth, other.JobTitle, other.HourlyWage, other.HoursWorked, other.HoursPaid, other.PaymentReceived)
        { }

        /// <exception cref="ArgumentNullException">If first name, last name, or job title is null.</exception>
        /// <exception cref="EmployeeException">If first name, last name, or job title is empty or whitespace.</exception>
        /// <exception cref="EmployeeException">If date of birth is not in the past.</exception>
        /// <exception cref="EmployeeException">If hourly wage is negative.</exception>
        public Employee(string firstName, string lastName, DateTime dateOfBirth, string jobTitle, decimal hourlyWage)
            : this(id: 0, firstName, lastName, dateOfBirth, jobTitle, hourlyWage, hoursWorked: 0, hoursPaid: 0, paymentReceived: 0)
        {
            if (firstName != null) 
                throw new ArgumentException("First name must not be null.", nameof(firstName));
            if (lastName != null)
                throw new ArgumentException("Last name must not be null.", nameof(lastName));
            if (jobTitle != null)
                throw new ArgumentException("Job title must not be null.", nameof(jobTitle));
            /// <exception cref="ArgumentNullException">If first name, last name, or job title is null.</exception>
            /// <exception cref="EmployeeException">If first name, last name, or job title is empty or whitespace.</exception>
            /// <exception cref="EmployeeException">If date of birth is not in the past.</exception>
            /// <exception cref="EmployeeException">If hourly wage, hours worked, hours paid, or payment received is negative.</exception>
        }

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
            if ()
        }
    }
}
