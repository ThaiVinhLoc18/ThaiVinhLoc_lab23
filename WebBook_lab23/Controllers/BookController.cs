using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBook_lab23.Models;
using System.ComponentModel.DataAnnotations;

namespace WebBook_lab23.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Hello Thầy Nguyễn Mạnh Hùng - University: " + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The comlpete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS Responsive web Design cook - Author Name Book 2");
            books.Add("Proffesional ASP.NET MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/sach1.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cook", "Author Name Book 2", "/Content/images/sach2.jpg"));
            books.Add(new Book(3, "Proffesional ASP.NET MVC", "Author Name Book 3", "/Content/images/sach3.jpg"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/sach1.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cook", "Author Name Book 2", "/Content/images/sach2.jpg"));
            books.Add(new Book(3, "Proffesional ASP.NET MVC", "Author Name Book 3", "/Content/images/sach3.jpg"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string Image_Cover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/sach1.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cook", "Author Name Book 2", "/Content/images/sach2.jpg"));
            books.Add(new Book(3, "Proffesional ASP.NET MVC", "Author Name Book 3", "/Content/images/sach3.jpg"));
            Book book = new Book();
            if (book == null) { return HttpNotFound(); }
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = Image_Cover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }
        public ActionResult CreateBook() { return View(); }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Id, Title, Author, Image_cover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/sach1.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cook", "Author Name Book 2", "/Content/images/sach2.jpg"));
            books.Add(new Book(3, "Proffesional ASP.NET MVC", "Author Name Book 3", "/Content/images/sach3.jpg"));
            try
            {
                if (ModelState.IsValid) { books.Add(book); }
            }
            catch(RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
    }
}