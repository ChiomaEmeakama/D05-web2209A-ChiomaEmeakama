using LibraryExam.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data;

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

            connectionString = ConfigurationManager.ConnectionStrings["LibraryExamDatabase"].ConnectionString;
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
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Title, TimesBorrowed, Borrower, BorrowDate, DueDate FROM dbo.Books";

            using SqlDataReader reader = command.ExecuteReader();
            List<Book> Books = new List<Book>();
            while (reader.Read())
                Books.Add(ReadNextBook(reader));

            return Books;
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
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //SELECT Id, Title, TimesBorrowed, Borrower, BorrowDate, DueDate" + "FROM dbo.Books
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE dbo.Books "
                + "SET TItle = @Title, TimesBorrowed = @TimesBorrowed, Borrower = @Borrower, "
                + "DueDate = @DueDate"
                + "WHERE Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.Int).Value = book.Id;
            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = book.Title;
            command.Parameters.Add("@TimesBorrowed", SqlDbType.DateTime2).Value = book.TimesBorrowed;
            command.Parameters.Add("@BorrowDate", SqlDbType.Int).Value = book.BorrowDate;
            command.Parameters.Add("@DueDate", SqlDbType.Bit).Value = book.DueDate;

           
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;

        }

        private Book ReadNextBook(SqlDataReader reader)
        {
            int Id = reader.GetInt32(0);
            string Title = reader.GetString(1);
            int TimesBorrowed = reader.GetInt32(2);
            string Borrower = reader.IsDBNull(3) ? null : reader.GetString(3); ;
            DateTime? BorrowDate = reader.IsDBNull(4)? null : reader.GetDateTime(4);
            DateTime? DueDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5);

            return new Book(Id, Title, TimesBorrowed, Borrower, BorrowDate, DueDate);
        }
    }
}
