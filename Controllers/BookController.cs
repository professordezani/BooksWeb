using Microsoft.AspNetCore.Mvc;
using BooksWeb.Models;

namespace BooksWeb.Controllers;

// https://localhost:1234/book/
public class BookController : Controller
{
    public static List<Book> books = new List<Book>();

    // https://localhost:1234/book/read
    // controller = classe
    // action = método
    public ActionResult Read()
    {        
        return View(books);
    }

    public ActionResult Create()
    {
        return View();
    }

    public ActionResult Create(Book model)
    {
        books.Add(model);
        return RedirectToAction("Read");
    }
}