using Microsoft.AspNetCore.Mvc;
using BooksWeb.Models;

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
        return View(db.Books.ToList()); // ~ SELECT * FROM Books
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
        db.SaveChanges();
        return RedirectToAction("Read");
    }
}