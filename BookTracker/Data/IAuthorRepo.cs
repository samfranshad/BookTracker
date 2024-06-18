using BookTracker.Models;

namespace BookTracker.Data
{
    public interface IAuthorRepo
    {
        public IEnumerable<Author> GetAllAuthors();
        public Author GetAuthor(int id);
        public void UpdateAuthor(Author author);
        public void InsertAuthor(Author authorToInsert);
        public void DeleteAuthor(Author author);
    }
}
