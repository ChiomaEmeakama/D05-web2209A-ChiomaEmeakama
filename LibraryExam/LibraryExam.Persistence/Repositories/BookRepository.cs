using LibraryExam.Domain.Entities;

namespace LibraryExam.Persistence.Repositories
{
    public class BookRepository
    {
        private readonly string connectionString;

        public BookRepository()
        {
            // TODO
            // Set the connectionString field to be the connection string named "LibraryExamDatabase"
            // from your App.config application configuration, by accessing ConfigurationManager
        }

        public List<Book> GetAllBooks()
        {
            // TODO
            // 	Create an SqlConnection using the connection string
            // 	Open the connection
            // 	Use the connection to create a command of type SqlCommand
            // 	Set the command text to be the correct SQL SELECT query: SELECT Id, Title, TimesBorrowed, Borrower, BorrowDate, DueDate FROM dbo.Books
            // 	Execute the command to get the returned SqlDataReader
            // 	Create a list of books
            // 	Read all the books from the data reader and add each to the list
                //  Read the Id column
                //  Read the Title column
                //  Read the TimesBorrowed column
                //  Read the Borrower column(first check whether it is DBNull)
                //  Read the BorrowDate column(first check whether it is DBNull)
                //  Read the DueDate column(first check whether it is DBNull)
                //  Create a new Book object using the data from the data reader
                //  Add the book to the list of books
            // 	Return the list of books

            return new List<Book>();
        }

        public bool UpdateBook(Book book)
        {
            // TODO
            // Create an SqlConnection using the connection string
            // Open the connection
            // Use the connection to create a command of type SqlCommand
            // Set the command text to be the correct SQL SELECT query:
                // UPDATE dbo.Books
                // SET Title = @Title, TimesBorrowed = @TimesBorrowed, Borrower = @Borrower, BorrowDate = @BorrowDate, DueDate = @DueDate
                // WHERE Id = @Id
            // Add all of the necessary parameters to the command
            // Execute the query (ExecuteNonQuery)
            // Return true if the number of rows affected is greater than 0 (success), and false otherwise (failure)

            return false;
        }
    }
}
