using BookTracker.Models;

namespace BookTracker.Data
{
    public interface IBookRepo
    {
        public IEnumerable<Book> GetAllBooks();

        public Book GetBook(int id);

        public void UpdateBook(Book book);

        public void InsertBook(Book bookToInsert);

        public void DeleteBook(Book book);

    }
}
