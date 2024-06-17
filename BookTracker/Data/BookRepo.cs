using BookTracker.Models;
using Dapper;
using System.Data;

namespace BookTracker.Data
{
    public class BookRepo : IBookRepo
    {
        private readonly IDbConnection _conn;
        public BookRepo (IDbConnection conn)
        {
            _conn = conn;
        }

        public void DeleteBook(Book book)
        {
            _conn.Execute("DELETE FROM books WHERE ID = @id", new { id = book.ID });
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _conn.Query<Book>("SELECT ID, Title, Author, Completed FROM books;");
        }

        public Book GetBook(int id)
        {
            return _conn.QuerySingle<Book>("SELECT * FROM books WHERE ID = @id", new {id = id});
        }

        public void InsertBook(Book bookToInsert)
        {
            _conn.Execute("INSERT INTO books (ISBN, Title, Author, YearPublished, Genre, Completed, Description) VALUES (@ISBN, @title, @author, @yearPublished, @genre, @completed, @description);",
                new { ISBN = bookToInsert.ISBN, title = bookToInsert.Title, author = bookToInsert.Author, yearPublished = bookToInsert.YearPublished, genre = bookToInsert.Genre, completed = bookToInsert.Completed, description = bookToInsert.Description });
        }

        public void UpdateBook(Book book)
        {
            _conn.Execute("UPDATE books SET ISBN = @ISBN, Title = @title, Author = @author, YearPublished = @yearPublished, Genre =  @genre, Completed = @completed, Description = @description WHERE ID = @id",
                new {ISBN = book.ISBN, title = book.Title, author = book.Author, yearPublished = book.YearPublished, genre = book.Genre, completed = book.Completed, description = book.Description, id = book.ID });
        }
    }
}
