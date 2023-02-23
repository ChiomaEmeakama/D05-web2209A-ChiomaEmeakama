using System;
using System.Collections.Generic;

namespace PassportApp.Models
{
    public class Passport
    {
        public int Id { get; }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    lastName = value;
            }
        }

        public DateTime DateOfBirth { get; }

        public string Country
        {
            get => country;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    country = value;
            }
        }

        public string FullName => $"{FirstName} {LastName}";
        public int Age => (int)(DateTime.UtcNow - DateOfBirth).TotalDays / 365;
        public string CurrentLocation => travelEvents[travelEvents.Count - 1].Country;
        public bool Traveling => CurrentLocation != Country;

        private readonly List<TravelEvent> travelEvents;
        private string firstName;
        private string lastName;
        private string country;
        private Passport passport;

        public Passport(int id, string firstName, string lastName, DateTime dateOfBirth, string country)
        {
            ValidateParameters(firstName, lastName, dateOfBirth, country);

            Id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            DateOfBirth = dateOfBirth;
            this.country = country;

            travelEvents = new List<TravelEvent>
            {
                new TravelEvent(id, country, DateTime.UtcNow)
            };
        }

        public Passport(int id, Passport passport)
        {
            Id = id;
            this.passport = passport;
        }

        private static void ValidateParameters(string firstName, string lastName, DateTime dateOfBirth, string country)
        {
            if (firstName == null)
                throw new ArgumentNullException(firstName);
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name must not be empty or whitespace.", nameof(firstName));

            if (lastName == null)
                throw new ArgumentNullException(lastName);
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name must not be empty or whitespace.", nameof(lastName));

            if (dateOfBirth > DateTime.UtcNow)
                throw new ArgumentOutOfRangeException(nameof(dateOfBirth), "Date of birth must not be in the future.");

            if (country == null)
                throw new ArgumentNullException(country);
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country must not be empty or whitespace.", nameof(country));
        }

        public void Travel(string country)
        {
            if (CurrentLocation != country)
                travelEvents.Add(new TravelEvent(Id, country, DateTime.UtcNow));
        }

        public override string ToString()
        {
            return $"Passport {Id} {FullName}";
        }
    }
}
