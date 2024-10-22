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
        var userName = HttpContext.Session.GetString("userName");
        ViewBag.userName = userName;
        // var x = db.BooksReaders.FromSql<BookReader>($"SELECT").ToList();
        var query = from book in db.Books  
             join br in db.BooksReaders.Include(book => book.Book) 
             on book.BookId equals br.BookId into bookreader
             from br in bookreader.DefaultIfEmpty() 
             select new BookReader  
             {
                BookId = book.BookId,
                Book = new Book {
                    Author = book.Author,
                    Title = book.Title,
                    Gender = book.Gender,
                    Synopsis = book.Synopsis
                },
                Status = br.Status,
                Score = br.Score,
             };
        return View(query.ToList()); // ~ SELECT * FROM Books
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

    public ActionResult Bookmark(int bookId) {
        var userId = HttpContext.Session.GetInt32("userId");
        Console.WriteLine(userId);
        db.BooksReaders.Add(new BookReader {
            BookId = bookId,
            ReaderId = (int)userId,
            Status = "Reading",
            Score = 0
        });
        db.SaveChanges();
        return RedirectToAction("Read");
    }
}