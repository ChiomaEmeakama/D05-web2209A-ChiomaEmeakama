using System;
using Chevalier.Utility.ViewModels;

namespace StudentApp.Models
{
    public class Student : ViewModel
    {
        public int Id { get; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        public DateTime DateOfBirth { get; set; }
        public int CoursesPassed { get; private set; }
        public bool Graduated { get; private set; }
        public DateTime? GraduationDate { get; private set; }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                TimeSpan duration = today - DateOfBirth;
                return (int)duration.TotalDays / 365;
            }
        }

        private const int RequiredCoursesForGraduation = 5;
        private string name;

        public Student(int id, string name, DateTime dateOfBirth)
            : this(id, name, dateOfBirth, coursesPassed: 0, graduated: false, graduationDate: null)
        { }

        public Student(int id, string name, DateTime dateOfBirth, int coursesPassed, bool graduated, DateTime? graduationDate)
        {
            if (graduated && coursesPassed < RequiredCoursesForGraduation)
                throw new ArgumentException(nameof(coursesPassed));
            if (graduated ^ graduationDate != null)
                throw new ArgumentException(nameof(graduationDate));

            Id = id;
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            DateOfBirth = dateOfBirth;
            CoursesPassed = coursesPassed;
            Graduated = graduated;
            GraduationDate = graduationDate;
        }

        public void PassCourse()
        {
            CoursesPassed++;
            NotifyPropertyChanged(nameof(CoursesPassed));
        }

        public void Graduate()
        {
            if (!Graduated && CoursesPassed > RequiredCoursesForGraduation)
            {
                Graduated = true;
                GraduationDate = DateTime.UtcNow;
                NotifyPropertyChanged(nameof(Graduated));
                NotifyPropertyChanged(nameof(GraduationDate));
            }
        }
    }
}
