using BookTracker.Data;
using BookTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepo repo;

        public BookController(IBookRepo repo)
        {
            this.repo = repo;
        }


        public async Task<IActionResult> Index (string sortOrder, string searchString)
        {
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "ID_desc" : "";
            ViewData["TitleSortParm"] = sortOrder == "Title" ? "title_desc" : "Title";
            ViewData["AuthorSortParm"] = sortOrder == "Author" ? "author_desc" : "Author";
            ViewData["CompletedSortParm"] = sortOrder == "Completed" ? "completed_desc" : "Completed";
            ViewData["CurrentFilter"] = searchString.ToLower();
            var books = from b in repo.GetAllBooks() select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString) || b.Author.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ID_desc":
                    books = books.OrderByDescending(b => b.ID); 
                    break;
                case "Title":
                    books = books.OrderBy(b => b.Title);
                    break;
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "Author":
                    books = books.OrderBy(b => b.Author);
                    break;
                case "author_desc":
                    books = books.OrderByDescending(b => b.Author);
                    break;
                case "Completed":
                    books = books.OrderBy(b => b.Completed);
                    break;
                case "completed_desc":
                    books = books.OrderByDescending(b => b.Completed);
                    break;
                default:
                    books = books.OrderBy(b => b.ID);
                    break;
            }
            return View(books);
        }


        public IActionResult ViewBook(int id)
        {
            var book = repo.GetBook(id);
            return View(book);
        }

        public IActionResult UpdateBook(int id) 
        {
            Book book = repo.GetBook(id);
            if (book == null)
            {
                return View("BookNotFound");
            }
            return View(book);
        }

        public IActionResult UpdateBookToDatabase(Book book)
        {
            repo.UpdateBook(book);

            return RedirectToAction("ViewBook", new { id = book.ID });
        }

        public IActionResult InsertBook()
        {
            var book = new Book();
            return View(book);
        }

        public IActionResult InsertBookToDatabase(Book bookToInsert)
        {
            repo.InsertBook(bookToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBook(Book book)
        {
            repo.DeleteBook(book);
            return RedirectToAction("Index");
        }
    }
}
