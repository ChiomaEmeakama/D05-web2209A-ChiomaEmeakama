using LibraryExam.Utility.ViewModels;
using LibraryExam.Domain.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace LibraryExam.Domain.Entities
{
    public class Book : ViewModel
    {
        public int Id { get; }
        public string Title { get; }

        public int TimesBorrowed
        {
            get => timesBorrowed;
            private set
            {
                timesBorrowed = value;
                NotifyPropertyChanged(nameof(TimesBorrowed));
            }
        }

        public string Borrower
        {
            get => borrower;
            private set
            {
                borrower = value;
                NotifyPropertyChanged(nameof(Borrower));
                NotifyPropertyChanged(nameof(Borrowed));
            }
        }

        public DateTime? BorrowDate
        {
            get => borrowDate;
            private set
            {
                borrowDate = value;
                NotifyPropertyChanged(nameof(BorrowDate));
            }
        }

        public DateTime? DueDate
        {
            get => dueDate;
            private set
            {
                dueDate = value;
                NotifyPropertyChanged(nameof(DueDate));
                NotifyPropertyChanged(nameof(Overdue));
                NotifyPropertyChanged(nameof(TimeOverdue));
                NotifyPropertyChanged(nameof(LateFee));
            }
        }

        public bool Borrowed => Borrower is not null;

        public bool Overdue
        {
            get
            {
                // TODO
                // Return true if and only if there is a due date and the due date is in the past
                // (earlier than the current time in UTC)
                if (DueDate != null && DueDate < DateTime.UtcNow)
                {
                    return true;
                }

                else

                    return false;
            }
        }
        public TimeSpan TimeOverdue
        {
            get
            {
                // TODO
                // If the book is overdue, return the positive time span from the due date to the current time in UTC
                // (Remember, use operators to do time math: DateTime - DateTime = TimeSpan)
                // Otherwise, return TimeSpan.Zero
                if (Overdue == true)
                {
                    TimeSpan timeOverdue = DateTime.UtcNow - dueDate.Value;
                    return timeOverdue;
                }

                return TimeSpan.Zero;
            }
        }

        public decimal LateFee
        {
            get
            {
                // TODO
                // If the book is overdue, then calculate and return the positive late fee:
                // Get the total number of seconds overdue from the time overdue property (TimeSpan.TotalSeconds)
                if (Overdue == true)
                {
                    decimal lateFee = ((int)TimeOverdue.TotalSeconds) * lateFeePerSecond;

                    if (lateFee > maxLateFee)
                    {
                        return maxLateFee;
                    }
                    else return lateFee;
                    // Calculate the late fee given the number of seconds overdue and a constant late fee per second of $1.95
                    // Round the late fee to two decimal points using Math.Round
                    // Return the late fee, or return the maximum late fee of $50.00 if the calculated late fee exceeds the maximum
                    // Otherwise, return $0.00
                }
                else
                    return (decimal)0.00;
            }
        }

        private static readonly TimeSpan borrowDuration = new TimeSpan(0, 0, seconds: 30);
        private static readonly decimal lateFeePerSecond = 1.95m;
        private static readonly decimal maxLateFee = 50.00m;

        private int timesBorrowed;
        private string borrower;
        private DateTime? borrowDate;
        private DateTime? dueDate;

        /// <summary>
        /// Create a book with the given title, and with default values for id, times borrowed, borrower, borrow date, and due date.
        /// This constructor should be used when creating a new book entity, before first inserting it into the database table.
        /// </summary>
        /// <param name="title">Book title. Must not be null, empty, or whitespace.</param>
        /// <exception cref="ArgumentNullException">If title is null.</exception>
        /// <exception cref="BookException">If title is empty or whitespace.</exception>
        public Book(string title)
            : this(id: 0, title, timesBorrowed: 0, borrower: null, borrowDate: null, dueDate: null)
        {
            Id = Id;
            title = title;
            this.timesBorrowed = timesBorrowed;
            this.borrower = borrower;
            this.borrowDate = borrowDate;
            this.dueDate = dueDate;

        }

        /// <summary>
        /// Create a book with the given id, by copying the other properties of the original book. This copy constructor should be used
        /// when creating a new book entity, after inserting it into the database table and receiving the database-generated id.
        /// </summary>
        /// <param name="id">Database-generated book id.</param>
        /// <param name="original">Original book object to be copied. Must not be null.</param>
        /// <exception cref="ArgumentNullException">If original is null.</exception>
        public Book(int id, Book original)
            : this(id, ValidateOriginal(original).Title, original.TimesBorrowed, original.Borrower, original.BorrowDate, original.DueDate)
        { }

        /// <summary>
        /// Create a book with the given properties. This fully-parameterized constructor should be used after executing a select query
        /// and reading an existing book entity from the result set returned from the database.
        /// </summary>
        /// <param name="id">Database-generated book id.</param>
        /// <param name="title">Book title. Must not be null, empty, or whitespace.</param>
        /// <param name="timesBorrowed">Number of times borrowed. Must not be less than 0.</param>
        /// <param name="borrower">Current borrower. Must not be empty or whitespace.</param>
        /// <param name="borrowDate">Current borrow date. If book is borrowed, must not be null. Otherwise, must be null.</param>
        /// <param name="dueDate">Current due date. If book is borrowed, must not be null. Otherwise, must be null.</param>
        /// <exception cref="ArgumentNullException">If title is null.</exception>
        /// <exception cref="BookException">If title is empty or whitespace.</exception>
        /// <exception cref="BookException">If times borrowed is less than 0 or less than 1 while borrower is not null.</exception>
        /// <exception cref="BookException">If borrower is empty or whitespace.</exception>
        /// <exception cref="BookException">If borrow date or due date is null while borrower is not null.</exception>
        /// <exception cref="BookException">If borrow date or due date is not null while borrower is null.</exception>
        public Book(int id, string title, int timesBorrowed, string borrower, DateTime? borrowDate, DateTime? dueDate)
        {
            ValidateParameters(title, timesBorrowed, borrower, borrowDate, dueDate);

            Id = id;
            Title = title;
            TimesBorrowed = timesBorrowed;
            Borrower = borrower;
            BorrowDate = borrowDate;
            DueDate = dueDate;
        }

        private static Book ValidateOriginal(Book original)
        {
            return original ?? throw new ArgumentNullException(nameof(original));
        }

        private static void ValidateParameters(string title, int timesBorrowed, string borrower, DateTime? borrowDate, DateTime? dueDate)
        {
            if (title is null)
                throw new ArgumentNullException(nameof(title));
            if (string.IsNullOrEmpty(title))
                throw new BookException("Title must not be empty.");
            if (string.IsNullOrWhiteSpace(title))
                throw new BookException("Title must not be whitespace.");
            if (timesBorrowed < 0)
                throw new BookException("Times borrowed must not be less than 0.");

            if (borrower is not null)
            {
                if (string.IsNullOrEmpty(borrower))
                    throw new BookException("Borrower must not be empty.");
                if (string.IsNullOrWhiteSpace(borrower))
                    throw new BookException("Borrower must not be whitespace.");
                if (timesBorrowed < 1)
                    throw new BookException("Times borrowed must not be less than 1 because the book is borrowed by {borrower}.");
                if (borrowDate is null)
                    throw new BookException($"A borrow date is required because the book is borrowed by {borrower}.");
                if (dueDate is null)
                    throw new BookException($"A due date is required because the book is borrowed by {borrower}.");
            }
            else
            {
                if (borrowDate is not null)
                    throw new BookException("There must be no borrow date because the book has no borrower.");
                if (dueDate is not null)
                    throw new BookException("There must be no due date because the book has no borrower.");
            }
        }

        public override string ToString()
        {
            return $"Book {Id} {Title}";
        }

        /// <summary>
        /// Borrows the book in the name of the given borrower. The book must not already be borrowed.
        /// Borrowing the book will update the borrower, borrow date, due date, and number of times borrowed.
        /// </summary>
        /// <param name="borrower">Name of the borrower. Must not be null, empty, or whitespace.</param>
        /// <exception cref="ArgumentNullException">If borrower is null.</exception>
        /// <exception cref="BookException">If borrower is empty or whitespace.</exception>
        /// <exception cref="BookException">If book is already borrowed.</exception>
        public void Borrow(string borrower)
        {
            // TODO
            // If the borrower parameter is null, throw an ArgumentNullException
            if (borrower == null)
            {
                throw new ArgumentNullException("Borrower must not be null.");
            }

            // If the book is already borrowed, throw a BookException with a clear message, such as "Cannot borrow book because it is already borrowed."
            if (Borrowed == true)
            {
                throw new BookException("Cannot borrow book because it is already borrowed.");
            }
            // If the borrower parameter is empty or whitespace, throw a BookException with a clear message
            if (string.IsNullOrWhiteSpace(borrower))
            {
                throw new BookException("Borrower must not be empty or a white space");
            }
            // Increase the book’s TimesBorrowed by 1

            TimesBorrowed++;

            // Set the book’s Borrower equal to the borrower parameter

            Borrower = borrower;

            // Set the book’s BorrowDate equal to the present time in UTC

            BorrowDate = DateTime.UtcNow;

            // Set the book’s DueDate equal to the BorrowDate plus a borrow duration of 30 seconds
            DueDate = BorrowDate.Value.AddSeconds(30);
        }

        /// <summary>
        /// Returns the book in the name of the given borrower. The book must already be borrowed by the borrower.
        /// Returning the book will remove the borrower, borrow date, and due date.
        /// </summary>
        /// <param name="borrower">Name of the borrower. Must not be null, empty, or whitespace.</param>
        /// <exception cref="ArgumentNullException">If borrower is null.</exception>
        /// <exception cref="BookException">If borrower is empty or whitespace.</exception>
        /// <exception cref="BookException">If book is not borrowed, or not not borrowed by the given borrower.</exception>
        public void Return(string borrower)
        {
            // TODO
            // If the borrower parameter is null, throw an ArgumentNullException
            if (borrower == null)
            {
                throw new ArgumentNullException("Borrower must not be null.");
            }
            // If the book is not currently borrowed, throw a BookException with a clear message, such as "Cannot return book because it is not currently borrowed."
            if (Borrowed == false)
            {
                throw new BookException("Cannot return book because it is not currently borrowed.");
            }
            // If the borrower parameter is empty or whitespace, throw a BookException with a clear message
            if (string.IsNullOrWhiteSpace(borrower))
            {
                throw new BookException("Borrower must not be empty or a white space");
            }
            // If the book’s Borrower is not equal to the borrower parameter, throw a BookException with a clear message(because only the original borrower can return the book)
            if (borrower != Borrower)
            {
                throw new BookException("because only the original borrower can return the book");
            }
            // Set the book’s Borrower equal to null
            Borrower = null;
            // Set the book’s BorrowDate equal to null
            BorrowDate = null;
            // Set the book’s DueDate equal to the null
            DueDate = null;
        }
    }
}
