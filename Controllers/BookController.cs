using Microsoft.AspNetCore.Mvc;
using BooksWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksWeb.Controllers;

// https://localhost:1234/book/
public class BookController : Controller
{
    private readonly BookDatabase db;

    public BookController(BookDatabase db) {
        this.db = db;
    }

    // https://localhost:1234/book/read
    // controller = classe
    // action = método
    public ActionResult Read()
    {     
        var userId = HttpContext.Session.GetInt32("userId");

        // Código SQL:
        // select * from Books
        //     left join BooksReaders 
        //     on Books.BookId = BooksReaders.BookId 
        //     and BooksReaders.ReaderId = 1

        // Código correspondente em LinQ:
        var query = from book in db.Books
             from bookReader in db.BooksReaders
                 .Where(br => br.ReaderId == userId)
                 .Where(br => br.BookId == book.BookId)
                 .DefaultIfEmpty()
             select new BookReader
             {
                BookId = book.BookId,
                Book = new Book {
                    Author = book.Author,
                    Title = book.Title,
                    Gender = book.Gender,
                    Synopsis = book.Synopsis
                },
                Status = bookReader.Status,
                Score = bookReader.Score,
             };
        return View(query.ToList());
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Book model)
    {
        db.Books.Add(model); // ~ INSERT INTO Books VALUES (mode.Title...)
        db.SaveChanges(); // ~ commit
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id) 
    {
        // realizar a exclusão
        var book = db.Books.Single(e => e.BookId == id); // SELECT * FROM Books WHERE BookId = id

        db.Books.Remove(book); // DELETE FROM Books WHERE BookId = id
        //db.Entry<Book>(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

        db.SaveChanges(); // commit

        // redirecionar para página de read novamente.
        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Book book = db.Books.Single(e => e.BookId == id);
        return View(book);
    }

    [HttpPost]
    public ActionResult Update(int id, Book model)
    {
        var book = db.Books.Single(e => e.BookId == id);

        book.Title = model.Title;
        book.Author = model.Author;
        book.Synopsis = model.Synopsis;
        book.Gender = model.Gender;

        db.SaveChanges();

        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Bookmark(int id, string status) {
        var userId = HttpContext.Session.GetInt32("userId");
        var bookReader = new BookReader {
            BookId = id,
            ReaderId = (int)userId,
            Status = status,
        };
        db.Entry(bookReader).State = status == "WantToRead" ?
                                   EntityState.Added :
                                   EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Read");
    }
}