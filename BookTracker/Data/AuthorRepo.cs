using BookTracker.Models;
using Dapper;
using System.Data;

namespace BookTracker.Data
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly IDbConnection _conn;

        public AuthorRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public void DeleteAuthor(Author author)
        {
            _conn.Execute("DELETE FROM authors WHERE AuthorID = @id;",
                new { id = author.AuthorID } );
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _conn.Query<Author>("SELECT AuthorID, AuthorName, BornDied, InLibrary FROM authors;");
        }

        public Author GetAuthor(int id)
        {
            return _conn.QuerySingle<Author>("SELECT * FROM authors WHERE AuthorID = @id;", new { id });

        }

        public void InsertAuthor(Author authorToInsert)
        {
            _conn.Execute("INSERT INTO authors (AuthorName, BornDied, InLibrary, NotableWorks, Bio) VALUES (@authorName, @bornDied, @inLibrary, @notableWorks, @bio);",
                new {authorName = authorToInsert.AuthorName, bornDied  = authorToInsert.BornDied, inLibrary = authorToInsert.InLibrary, notableWorks = authorToInsert.NotableWorks, bio = authorToInsert.Bio});
        }

        public void UpdateAuthor(Author author)
        {
            _conn.Execute("UPDATE authors SET AuthorName = @authorName, BornDied = @bornDied, InLibrary = @inLibrary, NotableWorks = @notableWorks, Bio = @bio WHERE AuthorID = @authorID",
                new {authorName = author.AuthorName, bornDied = author.BornDied, inLibrary = author.InLibrary, notableWorks = author.NotableWorks, bio = author.Bio, authorID = author.AuthorID});
        }
    }
}
