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
        //public IActionResult Index()
        //{
        //    var authors = repo.GetAllAuthors();
        //    return View(authors);
        //}

        public async Task<IActionResult> Index (string sortOrder, string searchString)
        {
            ViewData["AuthorIDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "authorID_desc" : "";
            ViewData["AuthorNameSortParm"] = sortOrder == "AuthorName" ? "authorName_desc" : "AuthorName";
            ViewData["BornDiedSortParm"] = sortOrder == "BornDied" ? "bornDied_desc" : "BornDied";
            ViewData["InLibrarySortParm"] = sortOrder == "InLibrary" ? "inLibrary_desc" : "InLibrary";
            ViewData["CurrentFilter"] = searchString;
            var authors = from a in repo.GetAllAuthors() select a;

            if(!String.IsNullOrEmpty(searchString) )
            {
                authors = authors.Where(a => a.AuthorName.Contains(searchString) || a.InLibrary.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "authorID_desc": 
                    authors = authors.OrderByDescending(a => a.AuthorID);
                    break;
                case "AuthorName":
                    authors = authors.OrderBy(a => a.AuthorName);
                    break;
                case "authorName_desc":
                    authors = authors.OrderByDescending(a => a.AuthorName);
                    break;
                case "BornDied":
                    authors = authors.OrderBy(a => a.BornDied);
                    break;
                case "bornDied_desc":
                    authors = authors.OrderByDescending(a => a.BornDied);
                    break;
                case "InLibrary":
                    authors = authors.OrderBy(a => a.InLibrary);
                    break;
                case "inLibrary_desc":
                    authors = authors.OrderByDescending(a => a.InLibrary);
                    break;
                default:
                    authors = authors.OrderBy(a => a.AuthorID);
                    break;
            }
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
