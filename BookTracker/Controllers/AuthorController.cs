using BookTracker.Data;
using BookTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace BookTracker.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepo repo;
        public AuthorController(IAuthorRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var authors = repo.GetAllAuthors();
            return View(authors);
        }

        public IActionResult ViewAuthor(int id)
        {
            var author = repo.GetAuthor(id);
            return View(author);
        }

        public IActionResult UpdateAuthor(int id)
        {
            Author author = repo.GetAuthor(id);
            if (author == null)
            {
                return View("AuthorNotFound");
            }
            return View(author);
        }

        public IActionResult UpdateAuthorToDatabase (Author author)
        {
            repo.UpdateAuthor(author);

            return RedirectToAction("ViewAuthor", new { id = author.AuthorID });
        }

        public IActionResult InsertAuthor()
        {
            var author = new Author();
            return View(author);
        }

        public IActionResult InsertAuthorToDatabase(Author authorToInsert)
        {
            repo.InsertAuthor(authorToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAuthor(Author author)
        {
            repo.DeleteAuthor(author);
            return RedirectToAction("Index");
        }
    }
}
