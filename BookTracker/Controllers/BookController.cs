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

        public IActionResult Index()
        {
            var books = repo.GetAllBooks();
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
