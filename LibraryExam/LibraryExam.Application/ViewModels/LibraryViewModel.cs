using System.Collections.ObjectModel;
using LibraryExam.Utility.Commands;
using LibraryExam.Utility.ViewModels;
using LibraryExam.Domain.Entities;
using LibraryExam.Persistence.Repositories;
using Microsoft.VisualBasic;

namespace LibraryExam.Application.ViewModels
{
    public class LibraryViewModel : ViewModel
    {
        public ObservableCollection<Book> Books { get; }
        
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                NotifyPropertyChanged(nameof(SelectedBook));
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                NotifyPropertyChanged(nameof(Message));
            }
        }

        public DelegateCommand RefreshCommand { get; }
        public DelegateCommand BorrowCommand { get; }
        public DelegateCommand ReturnCommand { get; }

        private readonly BookRepository repository;
        private Book selectedBook;
        private string name;
        private string message;

        public LibraryViewModel()
        {
            repository = new BookRepository();

            List<Book> books = repository.GetAllBooks();

            // TODO: Use the repository to get a list of all books from the database
            Books = new ObservableCollection<Book>(books); // TODO: Create the Books observable collection by copying the list from the repository
            


            selectedBook = null;
            name = string.Empty;
            message = "Select a book.";

            RefreshCommand = new DelegateCommand(Refresh);
            BorrowCommand = new DelegateCommand(Borrow);
            ReturnCommand = new DelegateCommand(Return);
        }

        private void Refresh(object _)
        {
            Book selectedBook = SelectedBook;
            if (selectedBook is not null)
            {
                SelectedBook = null;
                SelectedBook = selectedBook;
            }
        }

        private void Borrow(object _)
        {
            // TODO
            // If SelectedBook is not null:
                // Try to Borrow the selected book using Name (user input from text box) as the borrower
                // Use the repository to save changes to the book in the database, by calling UpdateBook
                // If the book was borrowed and updated correctly, set Message to display a clear success message, such as "Anna successfully borrowed Middlemarch."
                // Otherwise, if a BookException occurred, catch the exception and set Message to display the exception’s Message as an error message
            // Otherwise, set Message to display a clear error message, such as "Error: Select a book to borrow."
            if(SelectedBook is not null)
            {
                SelectedBook.Borrow(name);

            }
        }

        private void Return(object _)
        {
            // TODO
            // If SelectedBook is not null:
                // Access and store a local variable copy of SelectedBook’s computed properties: Overdue + TimeOverdue + LateFee
                // Try to Return the selected book using Name (user input from text box) as the borrower
                // Use the repository to save changes to the book in the database, by calling UpdateBook
                // If the book was returned and updated correctly, set Message to display a clear success message:
                    // If the book was overdue, display a success message including the name, title, time overdue, and the late fee paid
                    // Otherwise, if the book was returned on time, display a success message including only the name and title
                // Otherwise, if a BookException occurred, catch the exception and set Message to display the exception’s Message as an error message
            // Otherwise, set Message to display a clear error message

        }
    }
}
